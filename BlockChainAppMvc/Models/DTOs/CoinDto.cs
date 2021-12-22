using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models.DTOs
{
	public class CoinDto:IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Value { get; set; }
		public double ChangePerDay { get; set; }
	}
}
