using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCommunity.Data;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using FitnessCommunity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCommunity.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWeigtLogManageService _weigtLogManageService;
        private readonly IApplicationUserService _applicationUserService;

        public TableController(IMapper mapper, IWeigtLogManageService weigtLogManageService,
                                    IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _weigtLogManageService = weigtLogManageService;
            _applicationUserService = applicationUserService;
        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _applicationUserService.GetUserByName(this.User.Identity.Name);
            IEnumerable<TableWeightLogViewModel> tableWeightLogsViewModel =
                _mapper.Map<IEnumerable<TableWeightLogViewModel>>(await _weigtLogManageService.GetAllWeightLogs(user));

            if (user.MeasureType == Enums.MeasureType.lbs)
                tableWeightLogsViewModel = tableWeightLogsViewModel.Select(log => 
                                {
                                    var logForConvert = _mapper.Map<WeightLog>(log);
                                    log.WeightValue = WeightConverter.ConvertToLbs(logForConvert).WeightValue;
                                    return log;
                                });

            return View(tableWeightLogsViewModel);
        }
    }
}