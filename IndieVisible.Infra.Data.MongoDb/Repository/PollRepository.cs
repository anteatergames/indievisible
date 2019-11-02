using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class PollRepository : BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(IMongoContext context) : base(context)
        {
        }

        public override void Add(Poll obj)
        {
            foreach (var option in obj.Options)
            {
                option.Id = Guid.NewGuid();
            }

            base.Add(obj);
        }

        public void RemoveByContentId(Guid contentId)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<Poll>.Filter.Eq("userContentId", contentId)));
        }

        public async Task<bool> AddVote(Guid pollId, PollVote vote)
        {
            var filter = Builders<Poll>.Filter.Where(x => x.Id == vote.PollId);
            var add = Builders<Poll>.Update.AddToSet(c => c.Votes, vote);

            var result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveVote(Guid userId, Guid pollId)
        {
            var filter = Builders<Poll>.Filter.Where(x => x.Id == pollId);
            var remove = Builders<Poll>.Update.PullFilter(c => c.Votes, m => m.UserId == userId);

            var result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdateVote(PollVote vote)
        {
            var filter = Builders<Poll>.Filter.And(
                Builders<Poll>.Filter.Eq(x => x.Id, vote.PollId),
                Builders<Poll>.Filter.ElemMatch(x => x.Votes, x => x.UserId == vote.UserId));

            var update = Builders<Poll>.Update.Set(c => c.Votes[-1].PollOptionId, vote.PollOptionId);

            var result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public int CountVotes(Func<PollVote, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Votes).Count();
        }

        public Poll GetPollByOptionId(Guid optionId)
        {
            return DbSet.AsQueryable().FirstOrDefault(x => x.Options.Any(y => y.Id == optionId));
        }

        public IQueryable<PollVote> GetVotes(Guid pollId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == pollId).SelectMany(x => x.Votes);
        }

        public PollVote GetVote(Guid userId, Guid pollId)
        {
            return DbSet.Find(x => x.Id == pollId).First().Votes.SingleOrDefault(x => x.UserId == userId);
        }
    }
}
