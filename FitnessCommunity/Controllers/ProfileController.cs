using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using FitnessCommunity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCommunity.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly IApplicationUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProfileController(IApplicationUserService userService, IMapper mapper, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async  Task<IActionResult> Index()
        {
            ApplicationUser user = await _userService.GetUserByName(this.User.Identity.Name);
            ProfileViewModel profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid) return View("Index",profileViewModel);
            ApplicationUser user = await _userService.GetUserByName(this.User.Identity.Name);
            string currentEmail = user.Email;

            await _userService.UpdateUserProfile(profileViewModel,currentEmail);

            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public  IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordModel() { Token = token, Email = email });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetUrl = Url.Action("ResetPassword", "Profile",
                        new { token = token, email = user.Email }, Request.Scheme);

                    Console.WriteLine(resetUrl);
                    return Redirect(resetUrl);
                }
                else
                {
                    //send email and inform that they don't have account
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View();
                    }

                    if (_signInManager.IsSignedIn(this.User))
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else
                    {
                        return RedirectToAction(nameof(AccountController.Login), "Account");
                    }
                }
                ModelState.AddModelError("", "Invalid Request");
            }
            return View();
        }

    }
}