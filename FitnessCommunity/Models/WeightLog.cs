using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCommunity.Models
{
    public class WeightLog
    {
        public int WeightLogId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LogDate { get; set; }

        [Required]
        [Range(0.0,1000.0)]
        public float WeightValue { get; set; }
    }
}