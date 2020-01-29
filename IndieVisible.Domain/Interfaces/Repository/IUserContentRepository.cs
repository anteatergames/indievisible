using IndieVisible.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IUserContentRepository : IRepository<UserContent>
    {
        Task<int> CountComments(Expression<Func<UserContentComment, bool>> where);

        Task<IQueryable<UserContentComment>> GetComments(Expression<Func<UserContentComment, bool>> where);

        Task<IQueryable<UserContentLike>> GetLikes(Func<UserContentLike, bool> where);

        Task<bool> AddLike(UserContentLike model);

        Task<bool> RemoveLike(Guid userId, Guid userContentId);

        Task<bool> AddComment(UserContentComment model);
    }
}