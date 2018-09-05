using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Models.ViewModels
{
    public class TableWeightLogViewModel
    {
        public DateTime LogDate { get; set; }
        public float WeightValue { get; set; }
        public int Id { get; set; }
    }
}
