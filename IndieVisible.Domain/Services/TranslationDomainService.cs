using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class TranslationDomainService : BaseDomainMongoService<Localization, ILocalizationRepository>, ILocalizationDomainService
    {
        public TranslationDomainService(ILocalizationRepository repository) : base(repository)
        {
        }

        public Localization GenerateNewProject(Guid userId)
        {
            Localization model = new Localization
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

        public IEnumerable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language)
        {
            List<LocalizationEntry> entries = repository.GetEntries(projectId, language).ToList();

            return entries;
        }

        public DomainActionPerformed AddEntry(Guid projectId, LocalizationEntry entry)
        {
            IQueryable<LocalizationEntry> existing = repository.GetEntries(projectId, entry.Language, entry.TermId);
            bool oneIsMine = existing.Any(x => x.UserId == entry.UserId);

            if (oneIsMine)
            {
                entry.Id = existing.First(x => x.UserId == entry.UserId).Id;
                repository.UpdateEntry(projectId, entry);

                return DomainActionPerformed.Update;
            }
            else
            {
                entry.Value = entry.Value.Trim();

                bool existsWithSameValue = existing.Any(x => x.Value.Equals(entry.Value));
                if (!existing.Any() || !existsWithSameValue)
                {
                    repository.AddEntry(projectId, entry);

                    return DomainActionPerformed.Create;
                }
            }

            return DomainActionPerformed.None;
        }
        public void SaveEntries(Guid projectId, IEnumerable<LocalizationEntry> entries)
        {
            List<LocalizationEntry> existingEntrys = repository.GetEntries(projectId).ToList();

            foreach (LocalizationEntry entry in entries)
            {
                LocalizationEntry existing = existingEntrys.FirstOrDefault(x => x.TermId == entry.TermId && x.UserId == entry.UserId && x.Language == entry.Language);
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

        public IEnumerable<LocalizationTerm> GetTerms(Guid projectId)
        {
            List<LocalizationTerm> terms = repository.GetTerms(projectId).ToList();

            return terms;
        }


        public LocalizationStatsVo GetPercentageByGameId(Guid gameId)
        {
            LocalizationStatsVo model = repository.GetStatsByGameId(gameId);

            if (model == null)
            {
                return null;
            }

            IEnumerable<IGrouping<SupportedLanguage, LocalizationEntry>> languages = model.Entries.GroupBy(x => x.Language);

            int distinctEntriesCount = model.Entries.Select(x => new { x.TermId, x.Language }).Distinct().Count();
            int languageCount = model.Entries.Select(x => x.Language).Distinct().Count();

            double percentage = CalculatePercentage(model.TermCount, distinctEntriesCount, languageCount);
            model.LocalizationPercentage = percentage;


            return model;
        }

        public void SetTerms(Guid projectId, IEnumerable<LocalizationTerm> terms)
        {
            List<LocalizationTerm> existingTerms = repository.GetTerms(projectId).ToList();

            foreach (LocalizationTerm term in terms)
            {
                LocalizationTerm existing = existingTerms.FirstOrDefault(x => x.Id == term.Id);
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

            IEnumerable<LocalizationTerm> deleteTerms = existingTerms.Where(x => !terms.Contains(x));


            if (deleteTerms.Any())
            {
                List<LocalizationEntry> existingEntries = repository.GetEntries(projectId).ToList();
                foreach (LocalizationTerm term in deleteTerms)
                {
                    IEnumerable<LocalizationEntry> entries = existingEntries.Where(x => x.TermId == term.Id);
                    repository.RemoveTerm(projectId, term.Id);

                    foreach (LocalizationEntry entry in entries)
                    {
                        repository.RemoveEntry(projectId, entry.Id);
                    }
                }
            }
        }

        public Localization GetBasicInfoById(Guid id)
        {
            Localization obj = repository.GetBasicInfoById(id);

            return obj;
        }

        public void AcceptEntry(Guid projectId, Guid entryId)
        {
            LocalizationEntry entry = repository.GetEntry(projectId, entryId);
            if (entry != null)
            {
                entry.Accepted = true;
                repository.UpdateEntry(projectId, entry);
            }
        }

        public void RejectEntry(Guid projectId, Guid entryId)
        {
            LocalizationEntry entry = repository.GetEntry(projectId, entryId);
            if (entry != null)
            {
                entry.Accepted = false;
                repository.UpdateEntry(projectId, entry);
            }
        }

        public async Task<List<InMemoryFileVo>> GetXmlById(Guid projectId, bool fillGaps)
        {
            List<InMemoryFileVo> xmlTexts = new List<InMemoryFileVo>();

            Localization project = await repository.GetById(projectId);

            List<SupportedLanguage> languages = project.Entries.Select(x => x.Language).Distinct().ToList();
            languages.Add(project.PrimaryLanguage);

            foreach (SupportedLanguage language in languages)
            {
                string xmlText = GenerateLanguageXml(project, language, fillGaps);

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
            Localization project = await repository.GetById(projectId);

            string xmlText = GenerateLanguageXml(project, language, fillGaps);

            return new InMemoryFileVo
            {
                FileName = String.Format("{0}.xml", language.ToString().ToLower()),
                Contents = Encoding.UTF8.GetBytes(xmlText)
            };
        }

        public async Task<List<Guid>> GetContributors(Guid projectId, ExportContributorsType type)
        {
            List<Guid> contributorsIds = repository.GetEntries(projectId).Select(x => x.UserId).Distinct().ToList();

            return contributorsIds;
        }

        public double CalculatePercentage(int totalTerms, int translatedCount, int languageCount)
        {
            int totalTranslationsTarget = languageCount * totalTerms;

            double percentage = (100 * translatedCount) / (double)(totalTranslationsTarget == 0 ? 1 : totalTranslationsTarget);

            return percentage > 100 ? 100 : percentage;
        }

        private static string GenerateLanguageXml(Localization project, SupportedLanguage language, bool fillGaps)
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
                LocalizationTerm term = project.Terms.ElementAt(i);
                IOrderedEnumerable<LocalizationEntry> entries = project.Entries.Where(x => x.TermId == term.Id && x.Language == language).OrderBy(x => x.Accepted);

                if (entries.Any())
                {
                    LocalizationEntry lastAccepted = entries.LastOrDefault(x => !x.Accepted.HasValue || x.Accepted == true);
                    if (lastAccepted != null)
                    {
                        langValue = lastAccepted.Value;
                    }
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