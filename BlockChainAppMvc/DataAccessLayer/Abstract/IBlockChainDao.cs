using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities.BlockChain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlockChainAppMvc.DataAccessLayer.Abstract
{
    public interface IBlockChainDao : IEntityRepository<Blockchain>
    {
        List<Blockchain> getBlockchainsAll(Expression<Func<Blockchain, bool>> filter = null);
    }
}
