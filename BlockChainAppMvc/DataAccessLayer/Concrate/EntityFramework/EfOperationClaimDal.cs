using System;
using System.Collections.Generic;
using System.Text;
using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccess.Abstract;

namespace DataAccess.Concrate.EntityFrameWork
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, BlockChainAppContext>, IOperationClaimDal
    {
    }
}
