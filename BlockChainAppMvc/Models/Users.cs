using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.Models
{
	public class Users
	{
		public int Id { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public int walletId { get; set; }
	}
}
