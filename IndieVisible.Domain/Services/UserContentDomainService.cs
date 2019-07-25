using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndieVisible.Domain.Services
{
    public class UserContentDomainService : BaseDomainService<UserContent, IUserContentRepository>, IUserContentDomainService
    {
        private readonly IUserContentCommentRepository contentCommentRepository;

        public UserContentDomainService(IUserContentRepository repository
            , IUserContentCommentRepository contentCommentRepository) : base(repository)
        {
            this.contentCommentRepository = contentCommentRepository;
        }

        public int CountComments(Expression<Func<UserContentComment, bool>> where)
        {
            var count = contentCommentRepository.Count(where);

            return count;
        }

        public IEnumerable<UserContentComment> GetAllComments(Expression<Func<UserContentComment, bool>> where)
        {
            var comments = contentCommentRepository.Get(where);

            return comments;
        }
    }
}
