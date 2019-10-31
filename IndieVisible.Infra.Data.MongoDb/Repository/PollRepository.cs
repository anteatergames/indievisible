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

        public void AddVote(Guid pollId, PollVote vote)
        {
            var poll = DbSet.Find(x => x.Id == pollId).FirstOrDefault();

            if (poll != null)
            {
                var option = poll.Options.FirstOrDefault(x => x.Id == vote.PollOptionId);

                if (option != null)
                {
                    option.Votes = option.Votes ?? new List<PollVote>();
                    option.Votes.Add(vote);

                    DbSet.ReplaceOne(x => x.Id == pollId, poll);
                }
            }
        }

        public void RemoveVote(Guid userId, Guid optionId)
        {
            var poll = GetPollByOptionId(optionId);

            if (poll != null)
            {
                var option = poll.Options.FirstOrDefault(x => x.Id == optionId);

                if (option != null)
                {
                    var vote = option.Votes.FirstOrDefault(x => x.UserId == userId);

                    if (vote != null)
                    {
                        option.Votes = option.Votes ?? new List<PollVote>();
                        option.Votes.Remove(vote);

                        DbSet.ReplaceOne(x => x.Id == poll.Id, poll);
                    }
                }
            }
        }

        public int CountVotes(Func<PollVote, bool> where)
        {
            return DbSet.AsQueryable().SelectMany(x => x.Options).SelectMany(x => x.Votes).Count();
        }

        public Poll GetPollByOptionId(Guid optionId)
        {
            return DbSet.AsQueryable().FirstOrDefault(x => x.Options.Any(y => y.Id == optionId));
        }

        public IQueryable<PollVote> GetVotes(Guid pollId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == pollId).SelectMany(x => x.Options).SelectMany(x => x.Votes);
        }
    }
}
