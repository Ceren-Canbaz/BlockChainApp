using BlockChainAppMvc.DataAccessLayer.Abstract;
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
        //public List<WalletDto> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null)
        //{

        //    using (BlockChainAppContext context = new BlockChainAppContext())
        //    {
        //        var result = from w in context.Wallets
        //                     join u in context.Users
        //                         on w.userId equals u.Id
        //                     select new WalletDto()
        //                     {
        //                         UserId = w.userId,
        //                         UserName = u.Name,
        //                         UserLastName = u.LastName,
        //                         Balance = w.balance,
        //                         ToVerify = w.toVerify,
        //                         WalletId = w.walletId,


        //                     };
        //        return filter == null ? result.ToList() : result.Where(filter).ToList();
        //    }
        //}

<<<<<<< HEAD
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
=======
>>>>>>> 27953fbcf963b8fe372397692ed6f9b8a216826a

        //public List<WalletCoin> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null)
        //{


        //}

        public List<Wallet> getWalletWithChains(Expression<Func<Wallet, bool>> filter = null)
        {
          using (BlockChainAppContext context = new BlockChainAppContext())
            {
<<<<<<< HEAD
                var result = context.Wallets.Include(w => w.Coins).ToList();
                return result.ToList();
=======
                context.BlockChains.Include(b => b.Blocks).ToList();
                context.Blocks.Include(b => b.Coins);
                var result = context.Wallets.Include(w => w.Blockchains).ToList();


                return result;
>>>>>>> 27953fbcf963b8fe372397692ed6f9b8a216826a
            }
        }
    }
}

