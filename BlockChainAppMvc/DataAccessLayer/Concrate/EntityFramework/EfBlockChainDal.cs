using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess.EntityFramework;
using Core.Entities.BlockChain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
    public class EfBlockChainDal : EfEntityRepositoryBase<Blockchain, BlockChainAppContext>, IBlockChainDao
    {
        public List<Blockchain> getBlockchainsAll(Expression<Func<Blockchain, bool>> filter = null)
        {
            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                context.Blocks.Include(b => b.Coins);
                var result = context.BlockChains.Include(b => b.Blocks).ToList();
                return result.ToList();
            }
        }
    }
}
