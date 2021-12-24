using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDao : IEntityRepository<User>
    {
        List<UserDto> getAllUserDtos(Expression<Func<UserDto, bool>> filter = null);
        List<OperationClaim> GetClaims(User user);
    }
}
