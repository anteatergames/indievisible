﻿using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            int count = contentCommentRepository.Count(where);

            return count;
        }

        public IQueryable<UserContent> GetActivityFeed(Guid? gameId, Guid? userId, List<SupportedLanguage> languages, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly)
        {
            IQueryable<UserContent> allModels = repository.GetAll();

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

            return allModels;
        }

        public IEnumerable<UserContentComment> GetAllComments(Expression<Func<UserContentComment, bool>> where)
        {
            IQueryable<UserContentComment> comments = contentCommentRepository.Get(where);

            return comments;
        }

        public IQueryable<UserContentComment> GetComments(Expression<Func<UserContentComment, bool>> where)
        {
            IQueryable<UserContentComment> count = contentCommentRepository.Get(where);

            return count;
        }
    }
}
