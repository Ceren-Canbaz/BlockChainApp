using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlockChainAppMvc.DataAccessLayer.Abstract
{
	public interface IWalletDao : IEntityRepository<Wallet>
	{
		List<WalletDto> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null);
	}
}
