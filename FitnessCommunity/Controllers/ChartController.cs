﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using FitnessCommunity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FitnessCommunity.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ChartController : Controller
    {
        private readonly IWeigtLogManageService _weigtLogService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;
        public ChartController(IWeigtLogManageService weigtLogService,IApplicationUserService applicationUserService,IMapper mapper)
        {
            _weigtLogService = weigtLogService;
            _applicationUserService = applicationUserService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<WeightLog> weightLogs = await _weigtLogService.GetAllWeightLogs(await _applicationUserService.GetUserByName(this.User.Identity.Name));
            
            ViewBag.Title = "Data since starting weight";
            ApplicationUser user = await _applicationUserService.GetUserByName(User.Identity.Name);
            ViewBag.MeasureType = user.MeasureType;

            if (user.MeasureType == Enums.MeasureType.lbs)
                weightLogs = weightLogs.Select(log => WeightConverter.ConvertToLbs(log));
            IList<WeightLogViewModel> chartData = _mapper.Map<IEnumerable<WeightLogViewModel>>(weightLogs).ToList();
            ViewBag.WeightLogs = chartData.OrderBy(log => log.LogDate);
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisplayWeightLogsSinceDate(ChartViewModel chartViewModel)
        {
            IEnumerable<WeightLog> weightLogs = await _weigtLogService.GetWeightLogsSinceDate(await _applicationUserService.GetUserByName(this.User.Identity.Name),chartViewModel);
            IList<WeightLogViewModel> chartData = _mapper.Map<IEnumerable<WeightLogViewModel>>(weightLogs).ToList();
            ViewBag.WeightLogs = chartData.OrderBy(log => log.LogDate);
            if(chartViewModel.StartingDate!=null) ViewBag.Title ="Data since: "+chartViewModel.StartingDate.Value.ToLocalTime().ToShortDateString();
            return View("Index");
        }

    }
}