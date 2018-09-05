using FitnessCommunity.Data;
using FitnessCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Services
{
    public interface IWeigtLogManageService
    {
        IEnumerable<WeightLog> GetAllWeightLogs();
        WeightLog FindWeightLog(int id);
    }
    public class WeigtLogManageService : IWeigtLogManageService
    {
        ApplicationDbContext _context;

        public WeigtLogManageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public WeightLog FindWeightLog(int id)
        {
            return _context.WeightLogs.Find(id);
        }

        public IEnumerable<WeightLog> GetAllWeightLogs()
        {
            IAsyncEnumerable<WeightLog> asyncWeightLogs =  _context.WeightLogs.ToAsyncEnumerable();
            return asyncWeightLogs.ToEnumerable();
        }
    }
}
