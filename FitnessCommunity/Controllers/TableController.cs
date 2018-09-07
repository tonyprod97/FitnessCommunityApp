using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCommunity.Data;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using FitnessCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCommunity.Controllers
{
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
            ApplicationUser user = await _applicationUserService.GetUserByEmail(this.User.Identity.Name);
            IEnumerable<TableWeightLogViewModel> tableWeightLogsViewModel =
                _mapper.Map<IEnumerable<TableWeightLogViewModel>>(await _weigtLogManageService.GetAllWeightLogs(user));

            return View(tableWeightLogsViewModel);
        }
    }
}