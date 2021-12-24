using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace BlockChainAppMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
	{

        private ICoinService _coinService;

        public CoinsController(ICoinService coinService)
        {
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
	}
}
