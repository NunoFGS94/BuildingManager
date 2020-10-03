using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManager.Models;
using BuildingManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Controllers
{
    public class BuildingUserController : Controller
    {
        private readonly IMediator _mediator;

        public BuildingUserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: BuildingUserController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Index), "BuildingActivities");
        }

        // GET: BuildingUserController/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingUserController/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BuildingUserView buildingUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var query = new CreateUserQuery(buildingUser);
                    var result = await _mediator.Send(query);

                    if(result)
                        return RedirectToAction(nameof(Index), "BuildingActivities");
                }                  
                
                return View(nameof(Create), buildingUser);
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
                return View(nameof(Create), buildingUser);
            }
        }

        // Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(BuildingUserView buildingUser)
        {
            var query = new LoginUserQuery(buildingUser);
            var result = await _mediator.Send(query);

            if(result)
                return RedirectToAction(nameof(Index), "BuildingActivities");

            return View(nameof(Login), buildingUser);            
        }
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var query = new LogoutQuery();
            var result = await _mediator.Send(query);

            return RedirectToAction(nameof(Index), "BuildingActivities");
        }
    }
}
