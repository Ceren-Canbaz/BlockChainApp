using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
    public class Wallet :IEntity
    {
        public int id { get; set; }
        public decimal balance { get; set; }
		public int userId { get; set; }

		public bool toVerify { get; set; }
	}
}
