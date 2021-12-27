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
using Entities.DTOs;
using System.Net;
using BlockChainAppMvc.Models.DTOs;
using Microsoft.AspNetCore.Http;

namespace BlockChainAppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoinService _coinService;
        private IWalletService _walletService;
        private IAuthService _authService;
        public HomeController(ILogger<HomeController> logger, ICoinService coinService, IWalletService walletService, IAuthService authService)
        {
            
            _logger = logger;
            _coinService = coinService;
            _walletService = walletService;
            _authService = authService;
        }


        public IActionResult getAll()
        {
            
            var result = _walletService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest();
        }
        public IActionResult Index()
        {
          //  HttpContext.Session.SetString("token", _authService.Login().Data.);
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

        public IActionResult CoinsList()
        {
            return View(_coinService.GetAll().Data);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            //Session.Add("id","1");
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

        [HttpPost]
        public IActionResult CoinAmountBuy(int coinId, int numberOfCoin)
        {
            Coin coin = (Coin)_coinService.GetById(coinId);

            //string[] vs = new string[4];

            //vs[0] = coin.Split('-')[0];
            //vs[1] = coin.Split('-')[1];
            //vs[2] = coin.Split('-')[2];
            //vs[3] = coin.Split('-')[3];

            //int id = Convert.ToInt32(vs[0]);
            //string coinName = Convert.ToString(vs[1]);
            //decimal coinValue = Convert.ToDecimal(vs[2]);
            //decimal changePerDay = Convert.ToDecimal(vs[3]);

            //Coin _coin = new Coin()
            //{
            //    id = id,
            //    coinName = coinName,
            //    coinValue = coinValue,
            //    changePerDay = changePerDay
            //};

            return Redirect("Trade");
        }

        [HttpPost]
        public IActionResult CoinAmountSell(int coinId, int numberOfCoin)
        {
            Coin coin = (Coin)_coinService.GetById(coinId);

       
            return Redirect("Trade");
        }

        public IActionResult Trade()
        {
            string serkan = HttpContext.Session.GetString("coinName");

            List<Coin> list = new List<Coin>();

            Coin coin = new Coin()
            {
                id = 1,
                coinName = "BTC",
                coinValue = 3,
                changePerDay =3
            };


            list.Add(coin);

            return View(list);
        }

        [HttpPost]
        public ActionResult Trade(string coinId, int numberOfCoin /*CoinDto coinDto*/)
        {
            



            List<Coin> list = new List<Coin>();

            Coin coin = new Coin()
            {
                id = 1,
                coinName = "BTC",
                coinValue = 3,
                changePerDay = 3
            };

            list.Add(coin);


            return View(list);
        }

        public IActionResult Register()
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
