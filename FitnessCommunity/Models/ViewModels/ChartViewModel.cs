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
        [Display(Name ="Since")]
        public DateTime StartingDate { get; set; }

        public int NumberOfLogs { get; set; }
    }
}
