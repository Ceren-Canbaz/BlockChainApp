using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
    public class Coin :IEntity
    {
        public int id { get; set; }
        public string coinName { get; set; }
        public double coinValue { get; set; }
		public double changePerDay { get; set; }

	}
}
