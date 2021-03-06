﻿using FitnessCommunity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Public Info")]
        public string PublicInfo { get; set; }
        [Display(Name ="Measure Type")]
        public MeasureType? MeasureType { get; set; }
    }
}
