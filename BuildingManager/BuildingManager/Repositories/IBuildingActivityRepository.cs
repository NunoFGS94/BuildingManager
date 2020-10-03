using BuildingManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingManager.Repositories
{
    public interface IBuildingActivityRepository
    {
        Task<bool> CreateBuildingActivity(BuildingActivity buildingActivity);
        Task<bool> EndActivity(string userIdNr);
        Task<List<BuildingActivity>> GetCurrentBuildingActivities();
        Task<bool> IsUserInBuilding(string userIdNr);
    }
}