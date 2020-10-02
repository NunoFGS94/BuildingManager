using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingManager.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BuildingManager.Controllers
{
    public class BuildingActivitiesController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;

        public BuildingActivitiesController(IdentityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: BuildingActivities
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var activityList = await _context.BuildingActivities.Where(activity => !activity.exited).ToListAsync();

            List<BuildingActivityViewModel> buildingActivityList = new List<BuildingActivityViewModel>();
            activityList.ForEach(act => buildingActivityList.Add(_mapper.Map<BuildingActivityViewModel>(act)));

            ViewBag.InBuilding = false;
            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                ViewBag.InBuilding = buildingActivityList.Any(a => a.IdentificationNumber == currentUser.Identity.Name);
            }
            return View(buildingActivityList);
        }

        // GET: BuildingActivities/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var activityList = await _context.BuildingActivities.Where(activity => !activity.exited && activity.IdentificationNumber == User.Identity.Name).ToListAsync();

            var buildingActivity = activityList.FirstOrDefault();
            if(buildingActivity != null)
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
            var currentUser = this.User;
            BuildingActivity buildingActivity = _mapper.Map<BuildingActivity>(buildingActivityViewModel);

            if (ModelState.IsValid)
            {
                buildingActivity.IdentificationNumber = currentUser.Identity.Name;
                buildingActivity.ArrivalDate = DateTime.Now;
                buildingActivity.exited = false;
                _context.Add(buildingActivity);
                await _context.SaveChangesAsync();
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

            var activityList = await _context.BuildingActivities.Where(activity => !activity.exited && activity.IdentificationNumber == User.Identity.Name).ToListAsync();

            var buildingActivity = activityList.FirstOrDefault();
            if (buildingActivity == null)
            {
                return NotFound();
            }
            buildingActivity.exited = true;
            buildingActivity.ExitDate = DateTime.Now;
            _context.Update(buildingActivity);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

    }
}
