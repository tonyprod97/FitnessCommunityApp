using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FitnessCommunity.Services;

namespace FitnessCommunity.Controllers
{
    [Authorize]
    public class WeightLogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWeigtLogManageService _weigtLogManageService;
        private readonly IApplicationUserService _applicationUserService;

        public WeightLogController(IMapper mapper, IWeigtLogManageService weigtLogManageService,
                                    IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _weigtLogManageService = weigtLogManageService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ApplicationUser user = await _applicationUserService.GetUserByName(this.User.Identity.Name);
            ViewBag.MeasureType = user.MeasureType;
            return View(new WeightLogViewModel {
                LogDate = DateTime.Now
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeightLogViewModel weightLogViewModel )
        {
            if (ModelState.IsValid)
            {
                WeightLog newWeightLog = _mapper.Map<WeightLog>(weightLogViewModel);

                var user = await _applicationUserService.GetUserByName(this.User.Identity.Name);

                newWeightLog.User = user;

                newWeightLog = user.MeasureType == Enums.MeasureType.lbs ? WeightConverter.ConvertToKg(newWeightLog) : newWeightLog;

                await _weigtLogManageService.Add(newWeightLog);

                return RedirectToAction(nameof(TableController.Index), "Table"); ;
            }

            return View(weightLogViewModel);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            WeightLog weightLog = await _weigtLogManageService.FindWeightLogById(id);
            WeightLogViewModel weightLogViewModel = _mapper.Map<WeightLogViewModel>(weightLog);

            return View(weightLogViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(TableWeightLogViewModel weightLogViewModel)
        {
            await _weigtLogManageService.UpdateWeightLog(weightLogViewModel);

            return RedirectToAction(nameof(TableController.Index),"Table");
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            WeightLog weightLog = await _weigtLogManageService.FindWeightLogById(id);

            await _weigtLogManageService.Remove(weightLog);

            return RedirectToAction(nameof(TableController.Index), "Table");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
