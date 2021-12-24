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

namespace BlockChainAppMvc.DataAccessLayer.Concrate.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, BlockChainAppContext>, IUserDao
	{
		public List<UserDto> getAllUserDtos(Expression<Func<UserDto, bool>> filter = null)
		{
			using (BlockChainAppContext context=new BlockChainAppContext())
			{
				var result = from u in context.Users
							 join w in context.Wallets
							 on u.Id equals w.userId
							 select new UserDto()
							 {
								 Id=u.Id,
								 Name=u.Name,
								 LastName=u.LastName,
								 Address=u.Address,
								 Email=u.Email,
								 Phone=u.Phone,
								 TcNo=u.TcNo,
								 Balance=w.balance

							 };
			}
				throw new NotImplementedException();
		}
	}
}
