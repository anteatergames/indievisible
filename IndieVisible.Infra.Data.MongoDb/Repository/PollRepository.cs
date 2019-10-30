using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class PollRepository : BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(IMongoContext context) : base(context)
        {
        }

        public void AddVote(Guid pollId, PollVote vote)
        {
            //var filterPoll = Builders<Poll>.Filter.Eq(x => x.Id, pollId);
            //var filterOption = Builders<Poll>.Filter.Where(x => x.Options.Any
            //var add = Builders<Poll>.Update.AddToSet(c => c.Options, model);

            //var result = await DbSet.UpdateOneAsync(filterPoll, add);

            //return result.IsAcknowledged && result.MatchedCount > 0;
            throw new NotImplementedException();
        }

        public int CountVotes(Func<PollVote, bool> where)
        {
            throw new NotImplementedException();
        }

        public PollOption GetOptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PollVote> GetVotes(Guid pollId, Func<PollVote, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PollVote> GetVotes(Guid pollId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PollVote> GetVotes(Func<PollVote, bool> where)
        {
            throw new NotImplementedException();
        }

        public void UpdateVote(PollVote vote)
        {
            throw new NotImplementedException();
        }
    }
}
