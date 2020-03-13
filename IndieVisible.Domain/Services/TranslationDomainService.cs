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

        public void SetEntry(Guid projectId, TranslationEntry entry)
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
        public void SaveEntries(Guid projectId, IEnumerable<TranslationEntry> entries)
        {
            List<TranslationEntry> existingEntrys = repository.GetEntries(projectId).ToList();

            foreach (var entry in entries)
            {
                var existing = existingEntrys.FirstOrDefault(x => x.TermId == entry.TermId && x.UserId == entry.UserId);
                if (existing == null)
                {
                    entry.CreateDate = DateTime.Now;
                    repository.AddEntry(projectId, entry);
                }
                else
                {
                    existing.Value = entry.Value;
                    existing.LastUpdateDate = DateTime.Now;

                    repository.UpdateEntry(projectId, existing);
                }
            }
        }

        public IEnumerable<TranslationTerm> GetTerms(Guid projectId)
        {
            List<TranslationTerm> terms = repository.GetTerms(projectId).ToList();

            return terms;
        }

        public void SetTerms(Guid projectId, IEnumerable<TranslationTerm> terms)
        {
            List<TranslationTerm> existingTerms = repository.GetTerms(projectId).ToList();

            foreach (var term in terms)
            {
                var existing = existingTerms.FirstOrDefault(x => x.Id == term.Id);
                if (existing == null)
                {
                    repository.AddTerm(projectId, term);
                }
                else
                {
                    existing.Key = term.Key;
                    existing.Value = term.Value;
                    existing.Obs = term.Obs;
                    existing.LastUpdateDate = DateTime.Now;

                    repository.UpdateTerm(projectId, existing);
                }
            }
        }

        public TranslationProject GetBasicInfoById(Guid id)
        {
            var obj = repository.GetBasicInfoById(id);

            return obj;
        }
    }
}