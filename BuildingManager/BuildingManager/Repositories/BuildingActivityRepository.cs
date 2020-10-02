using AutoMapper;
using BuildingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Repositories
{
    public class BuildingActivityRepository : IBuildingActivityRepository
    {
        private readonly IdentityContext _context;

        public BuildingActivityRepository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<List<BuildingActivity>> GetCurrentBuildingActivities()
        {
            return _context.BuildingActivities.Where(activity => !activity.exited).ToList();
        }

        public bool IsUserInBuilding(string userIdNr)
        {
            return _context.BuildingActivities.Any(activity => (!activity.exited && activity.IdentificationNumber == userIdNr));
        }

        public async Task<bool> CreateBuildingActivity(BuildingActivity buildingActivity)
        {
            _context.Add(buildingActivity);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public bool EndActivity(string userIdNr)
        {
            var currentActivity = _context.BuildingActivities.Where(activity => !activity.exited && activity.IdentificationNumber == userIdNr).FirstOrDefault();
            currentActivity.exited = true;
            currentActivity.ExitDate = DateTime.Now;

            _context.Update(currentActivity);

            return true;
        }
    }
}
