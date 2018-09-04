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

namespace FitnessCommunity.Controllers
{
    [Authorize]
    public class ManageWeightController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ManageWeightController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult WeightLog(WeightLogViewModel weightLogViewModel, string returnUrl = null )
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                WeightLog newWeightLog = _mapper.Map<WeightLog>(weightLogViewModel);
                _context.Add(newWeightLog);
                _context.SaveChanges();

                return View();
            }

            return View(weightLogViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
