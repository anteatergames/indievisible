using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class ProfileRepository : Repository<UserProfile>, IProfileRepository
    {
        public ProfileRepository(IndieVisibleContext context) : base(context)
        {

        }

        public IEnumerable<UserProfile> GetByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId);
        }

        public void UpdateNameOnThePlatform(Guid userId, string newName)
        {
            var paramName = new SqlParameter("@newName", newName);
            var paramUserId = new SqlParameter("@userId", userId);

            var commandUpdateTeamMember = "update teammembers set Name= @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUpdateTeamMember, paramName, paramUserId);

            var commandUpdateGame = "update games set DeveloperName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUpdateGame, paramName, paramUserId);

            var commandUserContents = "update usercontents set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUserContents, paramName, paramUserId);

            var commandComments = "update comments set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandComments, paramName, paramUserId);

            var commandBrainstormComments = "update brainstormcomments set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandBrainstormComments, paramName, paramUserId);
        }
    }
}
