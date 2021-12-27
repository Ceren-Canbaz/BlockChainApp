using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess.EntityFramework;
using Core.Entities.BlockChain.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
    public class EfBlockDal : EfEntityRepositoryBase<Block, BlockChainAppContext>, IBlockDao
    {

    }
}
