using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models
{
    public class ResetPasswordViewModel
    {
        public string Token { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="New Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
