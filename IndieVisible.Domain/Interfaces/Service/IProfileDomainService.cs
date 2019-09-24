using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IProfileDomainService : IDomainService<UserProfile>
    {
        int CountFollow(Expression<Func<UserFollow, bool>> where);
        IEnumerable<UserFollow> GetFollows(Expression<Func<UserFollow, bool>> where);
    }
}
