﻿using AutoMapper;
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
        }
    }
}
