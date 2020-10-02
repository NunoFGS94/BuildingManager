using BuildingManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingManager.Repositories
{
    public interface IBuildingActivityRepository
    {
        Task<bool> CreateBuildingActivity(BuildingActivity buildingActivity);
        bool EndActivity(string userIdNr);
        Task<List<BuildingActivity>> GetCurrentBuildingActivities();
        bool IsUserInBuilding(string userIdNr);
    }
}