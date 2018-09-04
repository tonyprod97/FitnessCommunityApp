using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models.ViewModels
{
    public class WeightLogViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        public DateTime LogDate { get; set; } = DateTime.Now;

        [Required]
        [Range(0.0, 1000.0)]
        [Display(Name ="Weight")]
        public float WeightValue { get; set; }
    }
}
