using FitnessCommunity.Models.Enums;
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
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Public Info")]
        public string PublicInfo { get; set; }
        [Display(Name ="Measure Type")]
        public MeasureType MeasureType { get; set; }
    }
}
