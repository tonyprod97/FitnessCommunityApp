using AutoMapper;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Helpers
{
    public class ApplicationProfile: Profile
    {
        public ApplicationProfile()
        {
            CreateMap<WeightLog, WeightLogViewModel>();
            CreateMap<WeightLogViewModel, WeightLog>();
            CreateMap<WeightLog, TableWeightLogViewModel>();
            CreateMap<ApplicationUser, ProfileViewModel>();
            CreateMap<ProfileViewModel, ApplicationUser>();
            CreateMap<TableWeightLogViewModel, WeightLog>();
        }
    }
}
