
using BlockChainAppMvc.Models;
using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainAppMvc.DataAccessLayer.Abstract
{
	public interface ICoinDao : IEntityRepository<Coin>
	{
	
	}
}
