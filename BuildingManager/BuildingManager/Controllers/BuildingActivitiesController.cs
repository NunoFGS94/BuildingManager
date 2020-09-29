using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingManager.Models;

namespace BuildingManager.Controllers
{
    public class BuildingActivitiesController : Controller
    {
        private readonly ActivityContext _context;

        public BuildingActivitiesController(ActivityContext context)
        {
            _context = context;
        }

        // GET: BuildingActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activity.Where(activity => !activity.exited).ToListAsync());
        }

        // GET: BuildingActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingActivity = await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingActivity == null)
            {
                return NotFound();
            }

            return View(buildingActivity);
        }

        // GET: BuildingActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Motive,ArrivalDate,ExitDate,ExpectedExitDate,exited")] BuildingActivity buildingActivity)
        {
            if (ModelState.IsValid)
            {
                buildingActivity.ArrivalDate = DateTime.Now;
                buildingActivity.exited = false;
                _context.Add(buildingActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingActivity);
        }

        // GET: BuildingActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingActivity = await _context.Activity.FindAsync(id);
            if (buildingActivity == null)
            {
                return NotFound();
            }
            return View(buildingActivity);
        }

        // POST: BuildingActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Motive,ArrivalDate,ExitDate,ExpectedExitDate,exited")] BuildingActivity buildingActivity)
        {
            if (id != buildingActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingActivityExists(buildingActivity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buildingActivity);
        }

        // GET: BuildingActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingActivity = await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingActivity == null)
            {
                return NotFound();
            }

            return View(buildingActivity);
        }

        // POST: BuildingActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingActivity = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(buildingActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingActivityExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}
