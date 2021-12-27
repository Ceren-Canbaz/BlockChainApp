using BlockChainAppMvc.Business_Layer.Abstract;
using BlockChainAppMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using BlockChainAppMvc.BusinessLayer.Abstract;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;

namespace BlockChainAppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoinService _coinService;
        private IWalletService _walletService;
        private IAuthService _authService;
        private IUserService _userService;
        private IBlockService _blockService;
        private IBlockChainService _blockChainService;

        public HomeController(ILogger<HomeController> logger, ICoinService coinService,
            IWalletService walletService, IAuthService authService, IUserService userService
            , IBlockService blockService, IBlockChainService blockChainService)
        {
            _logger = logger;
            _coinService = coinService;
            _walletService = walletService;
            _authService = authService;
            _userService = userService;
            _blockService = blockService;
            _blockChainService = blockChainService;

        }

        [HttpGet("/getall")]
        public IActionResult getAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpGet("/getallUsersWallet")]
        public IActionResult getAllUsersWallet()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            //Session eklenecek
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {

                return View();
            }

            return BadRequest(result.Message);
        }
        public IActionResult Trade()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult CoinsList()
        {
            return View(_coinService.GetAll().Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/getallBlock")]
        public IActionResult getAllBlock()
        {
            var result = _blockService.GetAll();

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("/getallBlockId")]
        public IActionResult getAllBlock(int id)
        {
            var result = _blockService.GetById(id);

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("/addBlock")]
        public IActionResult addBlock(string data, decimal value)
        {
            var result = _blockService.FirstAddCoin(data, value);

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        //[HttpPost("/addWallet")]
        //public IActionResult addWallet(Wallet wallet)
        //{
        //    var result = _walletService.Add(wallet);

        //    if (!result.Success)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(result);
        //}


        [HttpGet("/getallBlockChain")]
        public IActionResult getallBlockChain()
        {
            var result = _blockChainService.GetAll();

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        [HttpPost("/addBlockChain")]
        public IActionResult addBlockChain(int id)
        {
            var result = _blockChainService.AddBlock(id);

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        //[HttpPost("/addBlockGenesis")]
        //public IActionResult addBlockChainGenesis(Blockchain blockchain, Block block)
        //{

        //    var result2 = _blockService.FirstAddCoin(block);

        //    if (result2.Success)
        //    {
        //        return Ok(result2);
        //    }

        //    return BadRequest();
        //}
    }
}
