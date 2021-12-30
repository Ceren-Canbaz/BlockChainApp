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
using Microsoft.AspNetCore.Http;
using BlockChainAppMvc.Core.Entities.Concrate;
using Core.Utilities.Security.Jwt;
using BlockChainAppMvc.ViewModels;

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
            HttpContext.Session.Clear();
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

                HttpContext.Session.SetString("token",result.Data.Token);
                string userId = Convert.ToString(userToLogin.Data.Id);
                HttpContext.Session.SetString("userId", userId);
                return View("Views/Home/Index.cshtml");
                
            }

            return BadRequest(result.Message);
        }


        [HttpPost("/coinAmountBuy")]
        public IActionResult coinAmountBuy(int coinId, decimal amount)
        {
            //int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            //Coin coinBuy = _coinService.GetById(coinId).Data;
            //_blockChainService.AddBlock(coinBuy.BlockId);
            ////int walletId = _walletService.GetByUserId(userId).Data.walletId;

            int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            var coinBuy = _coinService.GetById(coinId).Data;
            _blockChainService.AddBlock(coinBuy.blockId, amount);

      
            var wallet= _walletService.GetByUserId(userId).Data;


            wallet.balance+= coinBuy.coinValue * amount;
            _walletService.Update(wallet);
            

            return Redirect("/Home/Trade");
        }

        [HttpPost("/CoinAmountSell")]
        public IActionResult CoinAmountSell(int coinId, int amount)
        {
            Coin coinSell = _coinService.GetById(coinId).Data;
            int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            _blockChainService.AddBlock(coinSell.blockId, amount);
            var wallet = _walletService.GetByUserId(userId).Data;
            wallet.balance -= coinSell.coinValue * amount;
            _walletService.Update(wallet);
            return Redirect("/Home/Trade");
        }


        public IActionResult Trade()
        {
            var coins = _coinService.GetAll();
           
            int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            var wallet = _walletService.GetByUserId(userId).Data;
            List<Coin> _coins = coins.Data;
            
            CoinWalletModel coinwallet = new CoinWalletModel()
            {
                Coins = _coins,
                Wallets = wallet
            };
           


            //_coins
            return View(coinwallet);
        }

        [HttpGet]
        public IActionResult Wallet()
        {
            //int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            //var user=_userService.Get(userId).Data;
            //decimal coinAmount=0;
            //string coinName;
            

            //var blockchains = user.Wallet.Blockchains;
            
            //foreach (var item in blockchains)
            //{
            // var block=  item.Blocks;
            //    foreach (var blocks in block)
            //    {
            //         coinAmount = blocks.coinAmount;
                    
            //        foreach (var coin in block)
            //        {
            //            coinName = coin.Data;
            //        }
            //    }
            //}

           

            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToRegister = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (!userToRegister.Success)
            {
                return BadRequest(userToRegister.Message);
            }

            //Session eklenecek
            var result = _authService.CreateAccessToken(userToRegister.Data);
            if (result.Success)
            {
                //HttpContext.Session.SetString("userId", userToLogin.Data.Id.ToString());
                return View();
            }

            return Redirect("Login");
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
        public IActionResult addBlockChain(int id, decimal amount)
        {
            var result = _blockChainService.AddBlock(id, amount);

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
