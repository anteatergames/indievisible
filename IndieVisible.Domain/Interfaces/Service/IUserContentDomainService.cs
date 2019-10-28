using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IUserContentDomainService : IDomainService<UserContent>
    {
        int CountComments(Expression<Func<UserContentComment, bool>> where);
        int CountCommentsByUserId(Guid userId);
        IQueryable<UserContent> GetActivityFeed(Guid? gameId, Guid? userId, List<SupportedLanguage> languages, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly, int count);
        IQueryable<UserContentComment> GetComments(Expression<Func<UserContentComment, bool>> where);
    }
}
