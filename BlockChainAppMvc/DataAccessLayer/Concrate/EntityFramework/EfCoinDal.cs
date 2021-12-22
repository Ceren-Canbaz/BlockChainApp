using BlockChainAppMvc.EntityFrameWorkConfig;
using BlockChainAppMvc.Models;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using BlockChainAppMvc.DataAccessLayer.Abstract;

namespace DataAccess.Concrate.EntityFramework
{
	public class EfCoinDal :EfEntityRepositoryBase<Coin,BlockChainAppContext>,ICoinDao
	{
	}
}
