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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using FitnessCommunity.Helpers.Settings;
using Microsoft.Extensions.Options;

namespace FitnessCommunity.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly IApplicationUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailSenderService _emailSender;

        public ProfileController(IApplicationUserService userService, IMapper mapper, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<EmailSettings> emailSettings, EmailSenderService emailSender)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public async  Task<IActionResult> Index()
        {
            ApplicationUser user = await _userService.GetUserByName(this.User.Identity.Name);
            ProfileViewModel profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid) return View("Index",profileViewModel);
            ApplicationUser user = await _userService.GetUserByName(User.Identity.Name);

            await _userService.UpdateUserProfile(profileViewModel,user.Email);

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
            return View(new ResetPasswordViewModel() { Token = token, Email = email });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetUrl = Url.Action("ResetPassword", "Profile",
                        new { token = token, email = user.Email }, Request.Scheme);

                    _emailSender.ConfigureSendingMail(user.Email,resetUrl,true);
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }
                else
                {
                    var registerUrl = Url.Action("Register", "Account",
                        new RegisterViewModel { Email = forgotPasswordViewModel.Email }, Request.Scheme);
                    _emailSender.ConfigureSendingMail(forgotPasswordViewModel.Email, "You are unknown member for us. Please make sure that you have registered. You can reister here: "+registerUrl, false);
                    return RedirectToAction(nameof(AccountController.Register), "Account",
                        new RegisterViewModel() { Email = forgotPasswordViewModel.Email});
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);

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

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}