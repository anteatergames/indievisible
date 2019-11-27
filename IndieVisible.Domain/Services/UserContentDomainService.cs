using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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

        public new IEnumerable<UserContentSearchVo> Search(Expression<Func<UserContent, bool>> where)
        {
            IEnumerable<UserContent> all = base.Search(where);

            IEnumerable<UserContentSearchVo> selected = all.OrderByDescending(x => x.CreateDate)
                .Select(x => new UserContentSearchVo
                {
                    ContentId = x.Id,
                    Title = x.Title,
                    FeaturedImage = x.FeaturedImage,
                    Content = (string.IsNullOrWhiteSpace(x.Introduction) ? x.Content : x.Introduction).GetFirstWords(20),
                    Language = (x.Language == 0 ? SupportedLanguage.English : x.Language)
                });

            return selected;
        }

        public void AddLike(UserContentLike model)
        {
            Task.Run(async () => await repository.AddLike(model));
        }

        public bool CheckIfCommentExists<T>(Expression<Func<UserContentComment, bool>> where)
        {
            Task<IQueryable<UserContentComment>> task = repository.GetComments(where);

            task.Wait();

            bool exists = task.Result.Any();

            return exists;
        }

        public void Comment(UserContentComment model)
        {
            Task.Run(async () => await repository.AddComment(model));
        }

        public int CountComments(Expression<Func<UserContentComment, bool>> where)
        {
            Task<int> countTask = repository.CountComments(where);

            countTask.Wait();

            return countTask.Result;
        }

        public int CountCommentsByUserId(Guid userId)
        {
            Task<int> countTask = repository.CountComments(x => x.UserId == userId);

            countTask.Wait();

            return countTask.Result;
        }

        public IQueryable<UserContent> GetActivityFeed(Guid? gameId, Guid? userId, List<SupportedLanguage> languages, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly, int count)
        {
            IQueryable<UserContent> allModels = repository.Get();

            if (articlesOnly.HasValue && articlesOnly.Value)
            {
                allModels = allModels.Where(x => !string.IsNullOrEmpty(x.Title) && !string.IsNullOrEmpty(x.Introduction) && !string.IsNullOrEmpty(x.FeaturedImage) && x.Content.Length > 50);
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

            IQueryable<UserContent> finalList = orderedList.Take(count);

            return finalList;
        }

        public IQueryable<UserContentComment> GetComments(Expression<Func<UserContentComment, bool>> where)
        {
            Task<IQueryable<UserContentComment>> task = Task.Run(async () => await repository.GetComments(where));

            return task.Result;
        }

        public IEnumerable<UserContentLike> GetLikes(Func<UserContentLike, bool> where)
        {
            Task<IQueryable<UserContentLike>> task = Task.Run(async () => await repository.GetLikes(where));

            return task.Result;
        }

        public void RemoveLike(Guid currentUserId, Guid userContentId)
        {
            Task.Run(async () => await repository.RemoveLike(currentUserId, userContentId));
        }
    }
}