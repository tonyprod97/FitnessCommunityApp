using System;
using System.ComponentModel.DataAnnotations;


namespace FitnessCommunity.Models.ViewModels
{
    public class WeightLogViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime LogDate { get; set; }

        [Required]
        [Range(0.0, 1000.0)]
        [Display(Name ="Weight")]
        public Nullable<float> WeightValue { get; set; }

    }
}
