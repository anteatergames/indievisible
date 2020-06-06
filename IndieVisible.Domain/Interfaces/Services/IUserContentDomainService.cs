using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Services
{
    public interface IUserContentDomainService : IDomainService<UserContent>
    {
        new IEnumerable<UserContentSearchVo> Search(Expression<Func<UserContent, bool>> where);

        int CountComments(Expression<Func<UserContentComment, bool>> where);

        int CountCommentsByUserId(Guid userId);

        IQueryable<UserContent> GetActivityFeed(Guid? gameId, Guid? userId, List<SupportedLanguage> languages, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly, int count);

        IQueryable<UserContentComment> GetComments(Expression<Func<UserContentComment, bool>> where);

        void AddLike(UserContentLike model);

        IEnumerable<UserContentLike> GetLikes(Func<UserContentLike, bool> where);

        void RemoveLike(Guid currentUserId, Guid userContentId);

        bool CheckIfCommentExists<T>(Expression<Func<UserContentComment, bool>> where);

        void Comment(UserContentComment model);
    }
}