﻿using BlockChainAppMvc.DataAccessLayer.Abstract;
using BlockChainAppMvc.EntityFrameWorkConfig;
using BlockChainAppMvc.Models;
using BlockChainAppMvc.Models.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
    public class EfWalletDal : EfEntityRepositoryBase<Wallet, BlockChainAppContext>, IWalletDao
    {
        public List<WalletDto> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null)
        {

            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                var result = from w in context.Wallets
                             join u in context.Users
                                 on w.userId equals u.Id
                             select new WalletDto()
                             {
                                 UserId = w.userId,
                                 UserName = u.Name,
                                 UserLastName = u.LastName,
                                 Balance = w.balance,
                                 ToVerify = w.toVerify,
                                  id = w.id,


                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<Wallet> geTWalletsCoin(Expression<Func<Wallet, bool>> filter = null)
        {
          using (BlockChainAppContext context = new BlockChainAppContext())
            {
                var result = context.Wallets.Include(w => w.Coins).ToList();
                return result.ToList();
            }
        }
    }
}
