using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using FitnessCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCommunity.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IApplicationUserService _userService;
        private readonly IMapper _mapper;

        public ProfileController(IApplicationUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {
            ApplicationUser user = await _userService.GetUserByEmail(this.User.Identity.Name);
            ProfileViewModel profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }
    }
}