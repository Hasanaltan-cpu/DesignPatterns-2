using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ObserverDP.Models;
using WebApp.ObserverDP.Observer;

namespace BaseProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager ;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserObserverSubject _userObserverSubject;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 UserObserverSubject userObserverSubject )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userObserverSubject = userObserverSubject;
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



        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateVM userCreateDTO)
        {
            var user = new AppUser() { UserName = userCreateDTO.UserName, Email = userCreateDTO.Email };

            var identityResult = await _userManager.CreateAsync(user, userCreateDTO.Password);

            if (identityResult.Succeeded)
            {
                //Observer
                _userObserverSubject.NotifyObserver(user);

                ViewBag.Message = " User created has been succesfull";
            }
            else
            {
                ViewBag.Message = identityResult.Errors.ToList().First().Description;
            }

            return View();


        }
    }
}
