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
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private IWeigtLogManageService _weigtLogManageService;

        public WeightLogController(ApplicationDbContext context, IMapper mapper, IWeigtLogManageService weigtLogManageService)
        {
            _context = context;
            _mapper = mapper;
            _weigtLogManageService = weigtLogManageService;
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
                string userName = this.User.Identity.Name;
                var user = _context.Users.First(u => u.Email == userName);

                newWeightLog.ApplicationUser = user;
                _context.WeightLogs.Add(newWeightLog);
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(HomeController.Index), "Home"); ;
            }

            return View(weightLogViewModel);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditWeightLog(int id)
        {
            WeightLog weightLog = _weigtLogManageService.FindWeightLog(id);
            WeightLogViewModel weightLogViewModel = _mapper.Map<WeightLogViewModel>(weightLog);

            return View(weightLogViewModel);
        }

        [HttpPut("Edit/{id}")]
       /* public IActionResult EditWeightLog(int id)
        {
            WeightLog weightLog = _weigtLogManageService.FindWeightLog(id);
            WeightLogViewModel weightLogViewModel = _mapper.Map<WeightLogViewModel>(weightLog);

            return View(weightLogViewModel);
        }*/

        [HttpDelete("Delete/{id}")]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteWeightLog(int id)
        {
            WeightLog weightLog = _context.WeightLogs.First(wl => wl.Id == id);

            if (weightLog!=null)
            {
                _context.WeightLogs.Remove(weightLog);
                await _context.SaveChangesAsync();
                IEnumerable<TableWeightLogViewModel> newWeightLogs = _mapper.Map<IEnumerable<TableWeightLogViewModel>>(_weigtLogManageService.GetAllWeightLogs());
          
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
                _mapper.Map<IEnumerable<TableWeightLogViewModel>>(_weigtLogManageService.GetAllWeightLogs());
 
            return View("WeightLogsTable", tableWeightLogsViewModel);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetWeightLog(int id)
        {
            WeightLog weightLog = _weigtLogManageService.FindWeightLog(id);

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
