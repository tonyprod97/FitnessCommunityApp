using AutoMapper;
using FitnessCommunity.Data;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Services
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetUserByName(string userName);
        Task UpdateUserProfile(ProfileViewModel profileViewModel,string email);
    }
    public class ApplicationUserService: IApplicationUserService
    {
        private readonly ApplicationDbContext _conetxt;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public ApplicationUserService(ApplicationDbContext context,IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _conetxt = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public Task<ApplicationUser> GetUserByName(string userName)
        {
            return Task.Run(()=>
            {
                return _conetxt.Users.FirstOrDefault(u => u.UserName == userName);
            });
        }

        public Task UpdateUserProfile(ProfileViewModel profileViewModel,string email)
        {
            ApplicationUser applicationUser =  _conetxt.Users.First(user => user.Email == email);
            _mapper.Map(profileViewModel,applicationUser);
            _userManager.UpdateAsync(applicationUser);
            _conetxt.Users.Update(applicationUser);

            return _conetxt.SaveChangesAsync();

        }
    }
}
