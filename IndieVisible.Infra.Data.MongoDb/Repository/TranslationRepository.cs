using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class TranslationRepository : BaseRepository<Localization>, ILocalizationRepository
    {
        public TranslationRepository(IMongoContext context) : base(context)
        {
        }

        public Localization GetBasicInfoById(Guid id)
        {
            IFindFluent<Localization, Localization> obj = DbSet.Find(x => x.Id == id).Project(x => new Localization
            {
                Id = x.Id,
                UserId = x.UserId,
                CreateDate = x.CreateDate,
                LastUpdateDate = x.LastUpdateDate,
                GameId = x.GameId,
                PrimaryLanguage = x.PrimaryLanguage,
                Introduction = x.Introduction
            });

            return obj.FirstOrDefault();
        }

        public override void Add(Localization obj)
        {
            SetChildIds(obj);

            base.Add(obj);
        }

        public override void Update(Localization obj)
        {
            SetChildIds(obj);

            base.Update(obj);
        }

        #region Terms

        public int CountTerms(Func<LocalizationTerm, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Terms).Count();
        }

        public IQueryable<LocalizationTerm> GetTerms(Guid translationProjectId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == translationProjectId).SelectMany(x => x.Terms);
        }

        public async Task<bool> AddTerm(Guid translationProjectId, LocalizationTerm term)
        {
            term.Id = Guid.NewGuid();

            FilterDefinition<Localization> filter = Builders<Localization>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<Localization> add = Builders<Localization>.Update.AddToSet(c => c.Terms, term);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveTerm(Guid translationProjectId, Guid termId)
        {
            FilterDefinition<Localization> filter = Builders<Localization>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<Localization> remove = Builders<Localization>.Update.PullFilter(c => c.Terms, m => m.Id == termId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdateTerm(Guid translationProjectId, LocalizationTerm term)
        {
            FilterDefinition<Localization> filter = Builders<Localization>.Filter.And(
                Builders<Localization>.Filter.Eq(x => x.Id, translationProjectId),
                Builders<Localization>.Filter.ElemMatch(x => x.Terms, x => x.Id == term.Id));

            UpdateDefinition<Localization> update = Builders<Localization>.Update
                .Set(c => c.Terms[-1].Key, term.Key)
                .Set(c => c.Terms[-1].Value, term.Value)
                .Set(c => c.Terms[-1].Obs, term.Obs);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        #endregion Terms

        #region Entries

        public int CountEntries(Func<LocalizationEntry, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Entries).Count();
        }

        public IQueryable<LocalizationEntry> GetEntries(Guid translationProjectId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == translationProjectId).SelectMany(x => x.Entries);
        }

        public async Task<bool> AddEntry(Guid translationProjectId, LocalizationEntry entry)
        {
            entry.Id = Guid.NewGuid();

            FilterDefinition<Localization> filter = Builders<Localization>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<Localization> add = Builders<Localization>.Update.AddToSet(c => c.Entries, entry);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveEntry(Guid translationProjectId, Guid entryId)
        {
            FilterDefinition<Localization> filter = Builders<Localization>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<Localization> remove = Builders<Localization>.Update.PullFilter(c => c.Entries, m => m.Id == entryId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public void UpdateEntry(Guid translationProjectId, LocalizationEntry entry)
        {
            FilterDefinition<Localization> filter = Builders<Localization>.Filter.And(
                Builders<Localization>.Filter.Eq(x => x.Id, translationProjectId),
                Builders<Localization>.Filter.ElemMatch(x => x.Entries, x => x.Id == entry.Id));

            UpdateDefinition<Localization> update = Builders<Localization>.Update
                .Set(c => c.Entries[-1].Value, entry.Value)
                .Set(c => c.Entries[-1].Language, entry.Language)
                .Set(c => c.Entries[-1].Accepted, entry.Accepted);

            Context.AddCommand(() => DbSet.UpdateOneAsync(filter, update));
        }

        public IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId)
        {
            return DbSet.AsQueryable().Where(x => x.UserId == userId).Select(x => x.GameId).ToList();
        }

        #endregion Entries

        private void SetChildIds(Localization obj)
        {
            if (obj.Terms != null)
            {
                foreach (LocalizationTerm term in obj.Terms)
                {
                    if (term.Id == Guid.Empty)
                    {
                        term.Id = Guid.NewGuid();
                    }
                }
            }

            if (obj.Entries != null)
            {
                foreach (LocalizationEntry entry in obj.Entries)
                {
                    if (entry.Id == Guid.Empty)
                    {
                        entry.Id = Guid.NewGuid();
                    }
                }
            }
        }

        public IQueryable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language)
        {
            IQueryable<LocalizationEntry> translations = DbSet.AsQueryable().Where(x => x.Id == projectId).SelectMany(x => x.Entries).Where(x => x.Language == language);

            return translations;
        }

        public IQueryable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language, Guid termId)
        {
            IQueryable<LocalizationEntry> translations = DbSet.AsQueryable().Where(x => x.Id == projectId).SelectMany(x => x.Entries).Where(x => x.Language == language && x.TermId == termId);

            return translations;
        }

        public LocalizationEntry GetEntry(Guid projectId, Guid entryId)
        {
            var entry = DbSet.AsQueryable().Where(x => x.Id == projectId).SelectMany(x => x.Entries).FirstOrDefault(x => x.Id == entryId);

            return entry;
        }
    }
}