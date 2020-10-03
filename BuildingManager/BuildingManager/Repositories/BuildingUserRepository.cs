using BuildingManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Repositories
{
    public class BuildingUserRepository : IBuildingUserRepository
    {

        private readonly UserManager<BuildingUser> _userManager;
        private readonly SignInManager<BuildingUser> _signInManager;

        public BuildingUserRepository(UserManager<BuildingUser> userManager, SignInManager<BuildingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateUser(BuildingUser buildingUser)
        {
            buildingUser.UserName = buildingUser.IdentificationNumber.ToString();
            var existingUser = await _userManager.FindByNameAsync(buildingUser.UserName);

            if (existingUser == null)
            {
                var result = await _userManager.CreateAsync(buildingUser, buildingUser.UserPassword);
                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByNameAsync(buildingUser.UserName);
                    await _userManager.UpdateSecurityStampAsync(newUser);
                    await _signInManager.SignInAsync(newUser, false);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> LoginUser(BuildingUser buildingUser)
        {
            var result = await _signInManager.PasswordSignInAsync(buildingUser.IdentificationNumber.ToString(), buildingUser.UserPassword, false, false);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async void LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
