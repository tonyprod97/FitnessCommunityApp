using FitnessCommunity.Data;
using FitnessCommunity.Models;
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
        public ApplicationUserService(ApplicationDbContext context)
        {
            _conetxt = context;
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
