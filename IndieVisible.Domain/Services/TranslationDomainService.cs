using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Guid> gameIds = repository.GetTranslatedGamesByUserId(userId);

            return gameIds;
        }

        public IEnumerable<TranslationEntry> GetEntries(Guid projectId, SupportedLanguage language)
        {
            List<TranslationEntry> entries = repository.GetEntries(projectId, language).ToList();

            return entries;
        }

        public void SetTranslationEntry(Guid projectId, TranslationEntry entry)
        {
            var existing = repository.GetEntries(projectId, entry.Language, entry.TermId);
            var oneIsMine = existing.Any(x => x.UserId == entry.UserId);

            if (!existing.Any() || !oneIsMine)
            {
                repository.AddEntry(projectId, entry);
            }
            else
            {
                entry.Id = existing.First(x => x.UserId == entry.UserId).Id;
                repository.UpdateEntry(projectId, entry);
            }
        }
    }
}