using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessCommunity.Models;
using FitnessCommunity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using FitnessCommunity.Data;
using AutoMapper;
using FitnessCommunity.Services;

namespace FitnessCommunity.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class WeightLogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWeigtLogManageService _weigtLogManageService;
        private readonly IApplicationUserService _applicationUserService;

        public WeightLogController(ApplicationDbContext context, IMapper mapper, IWeigtLogManageService weigtLogManageService,
                                    IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _weigtLogManageService = weigtLogManageService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet("Create")]
        public IActionResult CreateWeightLog()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateWeightLog(WeightLogViewModel weightLogViewModel )
        {
            if (ModelState.IsValid)
            {
                WeightLog newWeightLog = _mapper.Map<WeightLog>(weightLogViewModel);

                var user = await _applicationUserService.GetUserByEmail(this.User.Identity.Name);

                newWeightLog.ApplicationUser = user;
                _weigtLogManageService.Add(newWeightLog);
                
                await _weigtLogManageService.Save();

                return RedirectToAction(nameof(HomeController.Index), "Home"); ;
            }

            return View(weightLogViewModel);
        }

        
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> EditWeightLog(int id)
        {
            WeightLog weightLog = await _weigtLogManageService.FindWeightLogById(id);
            WeightLogViewModel weightLogViewModel = _mapper.Map<WeightLogViewModel>(weightLog);

            return View(weightLogViewModel);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> EditWeightLog(TableWeightLogViewModel weightLogViewModel)
        {
            await _weigtLogManageService.UpdateWeightLog(weightLogViewModel);

            return RedirectToAction(nameof(WeightLogController.GetAllWeightLogs),"WeightLog");
        }
        
        [HttpDelete("Delete/{id}")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteWeightLog(int id)
        {
            WeightLog weightLog = await _weigtLogManageService.FindWeightLogById(id);

            if (weightLog!=null)
            {
                _weigtLogManageService.Remove(weightLog);
                await _weigtLogManageService.Save();
                IEnumerable<TableWeightLogViewModel> newWeightLogs = _mapper.Map<IEnumerable<TableWeightLogViewModel>>(await _applicationUserService.GetUserByEmail(this.User.Identity.Name));
          
                return View("WeightLogsTable",newWeightLogs);
            }
            else
            {
                return NotFound("Log on given date was not found.");
            }

        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllWeightLogs()
        {

            IEnumerable<TableWeightLogViewModel> tableWeightLogsViewModel =
                _mapper.Map<IEnumerable<TableWeightLogViewModel>>(await _weigtLogManageService.GetAllWeightLogs(await _applicationUserService.GetUserByEmail(this.User.Identity.Name)));
 
            return View("WeightLogsTable", tableWeightLogsViewModel);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetWeightLog(int id)
        {
            WeightLog weightLog =await _weigtLogManageService.FindWeightLogById(id);

            if (weightLog != null)
            {
                WeightLogViewModel weightLogViewModel = _mapper.Map<WeightLogViewModel>(weightLog);
                return View("CreateWeightLog", weightLogViewModel);
            }
            else
            {
                return NotFound("Log on given date was not found.");
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
