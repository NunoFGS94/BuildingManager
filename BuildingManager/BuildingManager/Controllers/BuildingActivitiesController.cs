using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildingManager.Models;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using BuildingManager.Queries;

namespace BuildingManager.Controllers
{
    public class BuildingActivitiesController : Controller
    {
        private readonly IMediator _mediator;

        public BuildingActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: BuildingActivities
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var query = new GetCurrentBuildingActivitiesQuery();
            var result = await _mediator.Send(query);

            ViewBag.InBuilding = false;
            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                ViewBag.InBuilding = result.Any(a => a.IdentificationNumber == currentUser.Identity.Name);
            }

            return View(result);
        }

        // GET: BuildingActivities/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            var query = new IsUserInBuildingQuery(User.Identity?.Name);
            var result = await _mediator.Send(query);
            if(result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // POST: BuildingActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Motive,ArrivalDate,ExitDate,ExpectedExitDate,exited")] BuildingActivityViewModel buildingActivityViewModel)
        {
            if (ModelState.IsValid)
            {
                var query = new CreateBuildingActivityQuery(buildingActivityViewModel, User.Identity.Name);
                var result = await _mediator.Send(query);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return View(buildingActivityViewModel);
        }

        // Exit
        [Authorize]
        public async Task<IActionResult> Exit()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return NotFound();
            }

            var query = new EndActivityQuery(User.Identity?.Name);
            var result = await _mediator.Send(query);
                        
            return RedirectToAction(nameof(Index));
        }

    }
}
