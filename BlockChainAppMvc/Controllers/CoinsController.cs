using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Controllers
{
	public class CoinsController : Controller
	{
		//getAll get interfaceteki bütün işlemlerin get ve post işlemlerini ekle
		
		public IActionResult Index()
		{
			return View();
		}

	}
}
