﻿using Core.DataAccess;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlockChainAppMvc.DataAccessLayer.Abstract
{
    public interface IBlockDao : IEntityRepository<Block>
    {
        // List<Block> getWalletWithChains(Expression<Func<Block, bool>> filter = null);
        List<Block> getWalletWithCoin(Expression<Func<Block, bool>> filter = null);


    }
}
