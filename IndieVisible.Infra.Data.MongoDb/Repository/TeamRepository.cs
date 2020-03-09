using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(IMongoContext context) : base(context)
        {
        }

        public TeamMember GetMembership(Guid teamId, Guid userId)
        {
            TeamMember member = DbSet.Find(x => x.Id == teamId).First().Members.SingleOrDefault(x => x.UserId == userId);

            return member;
        }

        public IQueryable<TeamMember> GetMemberships(Func<TeamMember, bool> where)
        {
            IQueryable<TeamMember> members = DbSet.AsQueryable().SelectMany(x => x.Members).Where(where).AsQueryable();

            return members;
        }

        public IQueryable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            return DbSet.AsQueryable().Where(x => x.Members.Any(y => y.UserId == userId));
        }

        public async Task<bool> RemoveMember(Guid teamId, Guid userId)
        {
            FilterDefinition<Team> filter = Builders<Team>.Filter.Where(x => x.Id == teamId);
            UpdateDefinition<Team> remove = Builders<Team>.Update.PullFilter(c => c.Members, m => m.UserId == userId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public void UpdateMembership(Guid teamId, TeamMember member)
        {
            FilterDefinition<Team> filter = Builders<Team>.Filter.And(
                Builders<Team>.Filter.Eq(x => x.Id, teamId)
                , Builders<Team>.Filter.ElemMatch(x => x.Members, x => x.UserId == member.UserId));

            UpdateDefinition<Team> update = Builders<Team>.Update.Combine(
                Builders<Team>.Update.Set(x => x.Members[-1].InvitationStatus, member.InvitationStatus)
                , Builders<Team>.Update.Set(x => x.Members[-1].Quote, member.Quote)
            );

            Context.AddCommand(() => DbSet.UpdateOneAsync(filter, update));
        }
    }
}