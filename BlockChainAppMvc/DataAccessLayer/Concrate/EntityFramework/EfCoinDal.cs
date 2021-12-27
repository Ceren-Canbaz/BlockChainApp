using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.EntityFrameWorkConfig;
using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCoinDal : EfEntityRepositoryBase<Coin, BlockChainAppContext>, ICoinDao
    {

    }
}
