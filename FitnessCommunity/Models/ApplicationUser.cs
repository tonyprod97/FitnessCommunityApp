using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<WeightLog> WeightLogs { get; set; }
    }
}
