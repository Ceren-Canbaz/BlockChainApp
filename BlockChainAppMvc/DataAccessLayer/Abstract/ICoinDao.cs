
using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlockChainAppMvc.DataAccessLayer.Abstract
{
    public interface ICoinDao : IEntityRepository<Coin>
    {
        //List<CoinDto> getCoinDtos(Expression<Func<CoinDto, bool>> filter = null);

    }
}
