using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class TranslationDomainService : BaseDomainMongoService<TranslationProject, ITranslationRepository>, ITranslationDomainService
    {
        public TranslationDomainService(ITranslationRepository repository) : base(repository)
        {
        }

        public TranslationProject GenerateNewProject(Guid userId)
        {
            TranslationProject model = new TranslationProject
            {
                UserId = userId
            };

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

        public void SaveEntry(Guid projectId, TranslationEntry entry)
        {
            IQueryable<TranslationEntry> existing = repository.GetEntries(projectId, entry.Language, entry.TermId);
            bool oneIsMine = existing.Any(x => x.UserId == entry.UserId);

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

            foreach (TranslationEntry entry in entries)
            {
                TranslationEntry existing = existingEntrys.FirstOrDefault(x => x.TermId == entry.TermId && x.UserId == entry.UserId && x.Language == entry.Language);
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

            foreach (TranslationTerm term in terms)
            {
                TranslationTerm existing = existingTerms.FirstOrDefault(x => x.Id == term.Id);
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

            IEnumerable<TranslationTerm> deleteTerms = existingTerms.Where(x => !terms.Contains(x));


            if (deleteTerms.Any())
            {
                List<TranslationEntry> existingEntries = repository.GetEntries(projectId).ToList();
                foreach (TranslationTerm term in deleteTerms)
                {
                    IEnumerable<TranslationEntry> entries = existingEntries.Where(x => x.TermId == term.Id);
                    repository.RemoveTerm(projectId, term.Id);

                    foreach (TranslationEntry entry in entries)
                    {
                        repository.RemoveEntry(projectId, entry.Id);
                    }
                }
            }
        }

        public TranslationProject GetBasicInfoById(Guid id)
        {
            TranslationProject obj = repository.GetBasicInfoById(id);

            return obj;
        }

        public async Task<List<InMemoryFileVo>> GetXmlById(Guid projectId, bool fillGaps)
        {
            List<InMemoryFileVo> xmlTexts = new List<InMemoryFileVo>();

            var project = await repository.GetById(projectId);

            var languages = project.Entries.Select(x => x.Language).Distinct().ToList();
            languages.Add(project.PrimaryLanguage);

            foreach (var language in languages)
            {
                var xmlText = GenerateLanguageXml(project, language, fillGaps);

                xmlTexts.Add(new InMemoryFileVo
                {
                    FileName = String.Format("{0}.xml", language.ToString().ToLower()),
                    Contents = Encoding.UTF8.GetBytes(xmlText)
                });
            }

            return xmlTexts;
        }

        public async Task<InMemoryFileVo> GetXmlById(Guid projectId, SupportedLanguage language, bool fillGaps)
        {
            var project = await repository.GetById(projectId);

            var xmlText = GenerateLanguageXml(project, language, fillGaps);

            return new InMemoryFileVo
            {
                FileName = String.Format("{0}.xml", language.ToString().ToLower()),
                Contents = Encoding.UTF8.GetBytes(xmlText)
            };
        }

        private static string GenerateLanguageXml(TranslationProject project, SupportedLanguage language, bool fillGaps)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<resources>");
            sb.AppendLine();

            sb.AppendLine(String.Format("<string id=\"lang_name\">{0}</string>", language.ToDisplayName()));
            sb.AppendLine(String.Format("<string id=\"lang_index\">{0}</string>", (int)language));
            sb.AppendLine();

            for (int i = 0; i < project.Terms.Count; i++)
            {
                string langValue = null;
                var term = project.Terms.ElementAt(i);
                var entry = project.Entries.FirstOrDefault(x => x.TermId == term.Id && x.Language == language);

                if (entry != null)
                {
                    langValue = entry.Value;
                }
                else
                {
                    if (fillGaps)
                    {
                        langValue = term.Value;
                    }
                }

                if (!string.IsNullOrWhiteSpace(langValue))
                {
                    sb.AppendLine(String.Format("<string id=\"{0}\">{1}</string>", term.Key, langValue));
                }
            }

            sb.AppendLine();
            sb.AppendLine("</resources>");

            return sb.ToString();
        }
    }
}