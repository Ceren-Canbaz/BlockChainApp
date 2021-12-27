using BlockChainAppMvc.EntityFrameWorkConfig;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BlockChainAppContext>, IUserDao
    {
        public List<UserDto> getAllUserDtos(Expression<Func<UserDto, bool>> filter = null)
        {
            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                var result = from u in context.Users
                             join w in context.Wallets
                             on u.Id equals w.userId
                             select new UserDto()
                             {
                                 Id = u.Id,
                                 Name = u.Name,
                                 LastName = u.LastName,
                                 Address = u.Address,
                                 Email = u.Email,
                                 Phone = u.Phone,
                                 TcNo = u.TcNo,
                                 Balance = w.balance

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<User> getAllUser(Expression<Func<User, bool>> filter = null)
        {
            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                context.BlockChains.Include(b => b.Blocks).ToList();
                context.Wallets.Include(w => w.Blockchains).ToList();
                var result = context.Users.Include(u => u.Wallet).ToList();
                return result;
            }

        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (BlockChainAppContext context = new BlockChainAppContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
