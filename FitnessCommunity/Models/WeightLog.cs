using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessCommunity.Models
{
    public class WeightLog
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }

        [Required]
        [Range(0.0,1000.0)]
        public float WeightValue { get; set; }
    }
}