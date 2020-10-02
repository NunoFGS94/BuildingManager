using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Controllers
{
    public class BuildingUserController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<BuildingUser> _userManager;
        private readonly SignInManager<BuildingUser> _signInManager;

        public BuildingUserController(IdentityContext context, UserManager<BuildingUser> userManager, SignInManager<BuildingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
        public async Task<ActionResult> Create(BuildingUser buildingUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var result = await _signInManager.PasswordSignInAsync(buildingUser.IdentificationNumber.ToString(), buildingUser.UserPassword, false, false);
                    buildingUser.UserName = buildingUser.IdentificationNumber.ToString();
                    var existingUser = await _userManager.FindByNameAsync(buildingUser.UserName);
                    if(existingUser == null)
                    {
                        var result = await _userManager.CreateAsync(buildingUser, buildingUser.UserPassword);
                        if (result.Succeeded)
                        {
                            var newUser = await _userManager.FindByNameAsync(buildingUser.UserName);
                            await _userManager.UpdateSecurityStampAsync(newUser);
                            await _signInManager.SignInAsync(newUser, false);
                            return RedirectToAction(nameof(Index), "BuildingActivities");
                        }
                        ViewBag.Result = result.Errors.FirstOrDefault();
                        return View(nameof(Create), buildingUser);
                    }
                    ViewBag.Result = "User already created";
                    return View(nameof(Create), buildingUser);
                }
                return View(nameof(Create));
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
        public async Task<ActionResult> Login(BuildingUser buildingUser)
        {
            try
            {

                var result = await _signInManager.PasswordSignInAsync(buildingUser.IdentificationNumber.ToString(), buildingUser.UserPassword, false, false);
                if (!result.Succeeded)
                {
                    ViewBag.Result = "Please check your credentials";
                    return View(nameof(Login), buildingUser);
                }
                return RedirectToAction(nameof(Index), "BuildingActivities");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index), "BuildingActivities");
        }
    }
}
