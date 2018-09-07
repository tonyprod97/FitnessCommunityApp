using FitnessCommunity.Data;
using FitnessCommunity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Services
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetUserByEmail(string email);
    }
    public class ApplicationUserService: IApplicationUserService
    {
        private readonly ApplicationDbContext _conetxt;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _conetxt = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<ApplicationUser> GetUserByEmail(string email)
        {
            return Task.Run(()=>
            {
                return _conetxt.Users.FirstOrDefault(u => u.Email == email);
            });
        }
    }
}
