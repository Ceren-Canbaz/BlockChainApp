using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models.DTOs
{
	public class WalletDto : IDto
	{
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public decimal Balance { get; set; }
        public bool ToVerify { get; set; }
        public int id { get; set; }
    }
}
