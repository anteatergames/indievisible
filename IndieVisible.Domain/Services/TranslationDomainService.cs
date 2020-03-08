using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Services
{
    public class TranslationDomainService : BaseDomainMongoService<TranslationProject, ITranslationRepository>, ITranslationDomainService
    {
        public TranslationDomainService(ITranslationRepository repository) : base(repository)
        {
        }

        public TranslationProject GenerateNewProject(Guid currentUserId)
        {
            TranslationProject model = new TranslationProject();

            return model;
        }

        public IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId)
        {
            var gameIds = repository.GetTranslatedGamesByUserId(userId);

            return gameIds;
        }
    }
}