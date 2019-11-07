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
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<TeamMember> GetMembership(Guid teamId, Guid userId)
        {
            var filter = Builders<Team>.Filter.And(
                Builders<Team>.Filter.Eq(x => x.Id, teamId)
                , Builders<Team>.Filter.ElemMatch(x => x.Members, x => x.UserId == userId));

            var obj = await DbSet.Find(filter).FirstOrDefaultAsync();

            return new TeamMember();
        }

        public IQueryable<TeamMember> GetMemberships(Func<TeamMember, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMember(Guid teamId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMembership(TeamMember member)
        {
            throw new NotImplementedException();
        }
    }
}
