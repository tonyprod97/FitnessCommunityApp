using FitnessCommunity.Data;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Services
{
    public interface IWeigtLogManageService
    {
        Task<IEnumerable<WeightLog>> GetAllWeightLogs(ApplicationUser user);
        Task<WeightLog> FindWeightLogById(Guid id);

        Task Add(WeightLog weightLog);

        Task Remove(WeightLog weightLog);
        Task UpdateWeightLog(TableWeightLogViewModel weightLogViewModel);
        Task<IEnumerable<WeightLog>> GetWeightLogsSinceDate(ApplicationUser user, ChartViewModel chartViewModel);
    }
    public class WeigtLogService : IWeigtLogManageService
    {
        ApplicationDbContext _context;

        public WeigtLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(WeightLog weightLog)
        {
            WeightLog weightLogFromDatabase = _context.WeightLogs.FirstOrDefault(wl => wl.LogDate == weightLog.LogDate);
            if (weightLogFromDatabase == null)
            {
                _context.WeightLogs.AddAsync(weightLog);
            }
            else
            {
                weightLogFromDatabase.WeightValue = weightLog.WeightValue;
                _context.WeightLogs.Update(weightLogFromDatabase);
            }

            return _context.SaveChangesAsync();
        }

        public Task<WeightLog> FindWeightLogById(Guid id)
        {
            return Task.Run(() =>
            {
                return _context.WeightLogs.Find(id);
            });
        }

        public Task<IEnumerable<WeightLog>> GetAllWeightLogs(ApplicationUser user)
        {
            return Task.Run(()=>
            {
                IAsyncEnumerable<WeightLog> asyncWeightLogs = _context.WeightLogs.Where(wl => wl.User.Id == user.Id).ToAsyncEnumerable();
                return asyncWeightLogs.ToEnumerable();

            });
        }

        public Task<IEnumerable<WeightLog>> GetWeightLogsSinceDate(ApplicationUser user, ChartViewModel chartViewModel)
        {
            return Task.Run(()=>
            {
                IEnumerable<WeightLog> weightLogs= _context.WeightLogs;

                if (chartViewModel.StartingDate != null)
                {
                    weightLogs= _context.WeightLogs.Where(wl => wl.User.Id == user.Id)
                                                        .Where(wl => DateTime.Compare(wl.LogDate, (DateTime)chartViewModel.StartingDate) > 0);
                }
                if (chartViewModel.NumberOfLogs != null)
                {
                    weightLogs = weightLogs.Take((int)chartViewModel.NumberOfLogs);
                }
               
                return weightLogs;
            });
        }

        public Task Remove(WeightLog weightLog)
        {
            _context.WeightLogs.Remove(weightLog);

            return _context.SaveChangesAsync();
        }

        public Task UpdateWeightLog(TableWeightLogViewModel weightLogViewModel)
        {
            return Task.Run(()=>
            {
                WeightLog weightLog = _context.WeightLogs.Find(weightLogViewModel.Id);

                weightLog.WeightValue = weightLogViewModel.WeightValue;

                _context.Update(weightLog);

                return _context.SaveChangesAsync();
            });
        }
    }
}
