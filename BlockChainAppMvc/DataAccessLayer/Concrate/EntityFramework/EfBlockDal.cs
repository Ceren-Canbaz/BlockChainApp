using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess.EntityFramework;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
    public class EfBlockDal : EfEntityRepositoryBase<Block, BlockChainAppContext>, IBlockDao
    {
        //public List<Block> getWalletWithChains(Expression<Func<Block, bool>> filter = null)
        //{

        //}

        public List<Block> getWalletWithCoin(Expression<Func<Block, bool>> filter = null)
        {
            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                var result = context.Blocks.Include(b => b.Coins);
                return result.ToList();
            }
        }
    }
}
