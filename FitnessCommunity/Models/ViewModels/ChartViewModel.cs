using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models.ViewModels
{
    public class ChartViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name ="Since: ")]
        public Nullable<DateTime> StartingDate { get; set; }


        [Display(Name ="Number of Logs: ")]
        [Range(1,int.MaxValue, ErrorMessage ="Only positive numbers allowed.")]
        public Nullable<int> NumberOfLogs { get; set; }
    }
}
