using BuildingManager.Models;
using System.Threading.Tasks;

namespace BuildingManager.Repositories
{
    public interface IBuildingUserRepository
    {
        Task<bool> CreateUser(BuildingUser buildingUser);
        Task<bool> LoginUser(BuildingUser buildingUser);
        void LogoutUser();
    }
}