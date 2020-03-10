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
    public class TranslationRepository : BaseRepository<TranslationProject>, ITranslationRepository
    {
        public TranslationRepository(IMongoContext context) : base(context)
        {
        }

        public override void Add(TranslationProject obj)
        {
            SetChildIds(obj);

            base.Add(obj);
        }

        public override void Update(TranslationProject obj)
        {
            SetChildIds(obj);

            base.Update(obj);
        }

        #region Terms

        public int CountTerms(Func<TranslationTerm, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Terms).Count();
        }

        public IQueryable<TranslationTerm> GetTerms(Guid translationProjectId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == translationProjectId).SelectMany(x => x.Terms);
        }

        public async Task<bool> AddTerm(Guid translationProjectId, TranslationTerm term)
        {
            term.Id = Guid.NewGuid();

            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<TranslationProject> add = Builders<TranslationProject>.Update.AddToSet(c => c.Terms, term);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveTerm(Guid translationProjectId, Guid termId)
        {
            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<TranslationProject> remove = Builders<TranslationProject>.Update.PullFilter(c => c.Terms, m => m.Id == termId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdateTerm(Guid translationProjectId, TranslationTerm term)
        {
            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.And(
                Builders<TranslationProject>.Filter.Eq(x => x.Id, translationProjectId),
                Builders<TranslationProject>.Filter.ElemMatch(x => x.Terms, x => x.Id == term.Id));

            UpdateDefinition<TranslationProject> update = Builders<TranslationProject>.Update
                .Set(c => c.Terms[-1].Key, term.Key)
                .Set(c => c.Terms[-1].Value, term.Value)
                .Set(c => c.Terms[-1].Obs, term.Obs);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        #endregion Terms

        #region Entries

        public int CountEntries(Func<TranslationEntry, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Entries).Count();
        }

        public IQueryable<TranslationEntry> GetEntries(Guid translationProjectId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == translationProjectId).SelectMany(x => x.Entries);
        }

        public async Task<bool> AddEntry(Guid translationProjectId, TranslationEntry entry)
        {
            entry.Id = Guid.NewGuid();

            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<TranslationProject> add = Builders<TranslationProject>.Update.AddToSet(c => c.Entries, entry);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveEntry(Guid translationProjectId, Guid entryId)
        {
            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.Where(x => x.Id == translationProjectId);
            UpdateDefinition<TranslationProject> remove = Builders<TranslationProject>.Update.PullFilter(c => c.Entries, m => m.Id == entryId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdateEntry(Guid translationProjectId, TranslationEntry entry)
        {
            FilterDefinition<TranslationProject> filter = Builders<TranslationProject>.Filter.And(
                Builders<TranslationProject>.Filter.Eq(x => x.Id, translationProjectId),
                Builders<TranslationProject>.Filter.ElemMatch(x => x.Entries, x => x.Id == entry.Id));

            UpdateDefinition<TranslationProject> update = Builders<TranslationProject>.Update
                .Set(c => c.Entries[-1].Value, entry.Value)
                .Set(c => c.Entries[-1].Language, entry.Language);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId)
        {
            return DbSet.AsQueryable().Where(x => x.UserId == userId).Select(x => x.GameId).ToList();
        }

        #endregion Entries

        private void SetChildIds(TranslationProject obj)
        {
            if (obj.Terms != null)
            {
                foreach (TranslationTerm term in obj.Terms)
                {
                    if (term.Id == Guid.Empty)
                    {
                        term.Id = Guid.NewGuid();
                    }
                }
            }

            if (obj.Entries != null)
            {
                foreach (TranslationEntry entry in obj.Entries)
                {
                    if (entry.Id == Guid.Empty)
                    {
                        entry.Id = Guid.NewGuid();
                    }
                }
            }
        }

        public IQueryable<TranslationEntry> GetEntries(Guid projectId, SupportedLanguage language)
        {
            IQueryable<TranslationEntry> translations = DbSet.AsQueryable().Where(x => x.Id == projectId).SelectMany(x => x.Entries).Where(x => x.Language == language);

            return translations;
        }

        public IQueryable<TranslationEntry> GetEntries(Guid projectId, SupportedLanguage language, Guid termId)
        {
            IQueryable<TranslationEntry> translations = DbSet.AsQueryable().Where(x => x.Id == projectId).SelectMany(x => x.Entries).Where(x => x.Language == language && x.TermId == termId);

            return translations;
        }
    }
}