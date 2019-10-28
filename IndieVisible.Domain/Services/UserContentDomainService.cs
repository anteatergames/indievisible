using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class UserContentDomainService : BaseDomainMongoService<UserContent, IUserContentRepository>, IUserContentDomainService
    {
        public UserContentDomainService(IUserContentRepository repository) : base(repository)
        {
        }

        public int CountComments(Expression<Func<UserContentComment, bool>> where)
        {
            var countTask = repository.CountComments(where);

            countTask.Wait();

            return countTask.Result;
        }


        public int CountCommentsByUserId(Guid userId)
        {
            var countTask = repository.CountComments(x => x.UserId == userId);

            countTask.Wait();

            return countTask.Result;
        }

        public IQueryable<UserContent> GetActivityFeed(Guid? gameId, Guid? userId, List<SupportedLanguage> languages, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly, int count)
        {
            var allModels = repository.Get();

            if (articlesOnly.HasValue && articlesOnly.Value)
            {
                allModels = allModels.Where(x => !string.IsNullOrWhiteSpace(x.Title) && !string.IsNullOrWhiteSpace(x.Introduction) && !string.IsNullOrWhiteSpace(x.FeaturedImage) && x.Content.Length > 50);
            }

            if (userId.HasValue && userId != Guid.Empty)
            {
                allModels = allModels.Where(x => x.UserId != Guid.Empty && x.UserId == userId);
            }

            if (gameId.HasValue && gameId != Guid.Empty)
            {
                allModels = allModels.Where(x => x.GameId != Guid.Empty && x.GameId == gameId);
            }

            if (languages != null && languages.Any())
            {
                allModels = allModels.Where(x => x.Language == 0 || languages.Contains(x.Language));
            }

            if (oldestDate.HasValue)
            {
                allModels = allModels.Where(x => x.CreateDate <= oldestDate && x.Id != oldestId);
            }

            IOrderedQueryable<UserContent> orderedList = allModels
                .OrderByDescending(x => x.CreateDate);

            var finalList = orderedList.Take(count);

            return finalList;
        }

        public IQueryable<UserContentComment> GetComments(Expression<Func<UserContentComment, bool>> where)
        {
            var comments = Task.Run(async () => await repository.GetComments(where));//  contentCommentRepository.Get(where);

            return comments.Result;
        }
    }
}
