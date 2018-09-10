using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models.ViewModels
{
    public class TableWeightLogViewModel
    {
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }
        public float WeightValue { get; set; }
        public Guid Id { get; set; }
    }
}
