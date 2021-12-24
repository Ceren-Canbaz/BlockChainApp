using BlockChainAppMvc.Business_Layer.Abstract;
using BlockChainAppMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;


namespace BlockChainAppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoinService _coinService;
        public HomeController(ILogger<HomeController> logger, ICoinService coinService)
        {
            _logger = logger;
            _coinService = coinService;
        }

        [HttpGet("/getall")]
        public IActionResult getAll()
        {
            var result = _coinService.GetAll();
            if (result.Success)
            {
                return Ok(200);
            }

            return BadRequest();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ExamForRoute()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
