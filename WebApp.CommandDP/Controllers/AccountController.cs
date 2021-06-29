using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.CommandDP.Controllers;
using WebApp.CommandDP.Models;

namespace BaseProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager ;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Login(string email,string password)
        {
            var hasUser = await _userManager.FindByEmailAsync(email);

            if (hasUser == null) return View();

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser,password,true,false);


            //if (signInResult.RequiresTwoFactor) /*If need Two Factor Authentication*/
            //{

            //}


            if (!signInResult.Succeeded)
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");


        }



        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
