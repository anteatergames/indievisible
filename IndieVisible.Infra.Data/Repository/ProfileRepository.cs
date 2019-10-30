using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class ProfileRepository : Repository<UserProfile>, IProfileRepositorySql
    {
        public ProfileRepository(IndieVisibleContext context) : base(context)
        {

        }

        public override UserProfile GetById(Guid id)
        {
            return DbSet.Where(x => x.Id == id).Include(x => x.ExternalLinks).FirstOrDefault();
        }

        public override IQueryable<UserProfile> GetByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId).Include(x => x.ExternalLinks);
        }

        public void UpdateNameOnThePlatform(Guid userId, string newName)
        {
            SqlParameter paramName = new SqlParameter("@newName", newName);
            SqlParameter paramUserId = new SqlParameter("@userId", userId);

            string commandUpdateTeamMember = "update teammembers set Name= @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUpdateTeamMember, paramName, paramUserId);

            string commandUpdateGame = "update games set DeveloperName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUpdateGame, paramName, paramUserId);

            string commandUserContents = "update usercontents set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandUserContents, paramName, paramUserId);

            string commandComments = "update comments set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandComments, paramName, paramUserId);

            string commandBrainstormComments = "update brainstormcomments set AuthorName = @newName where UserId = @userId";
            Db.Database.ExecuteSqlCommand(commandBrainstormComments, paramName, paramUserId);
        }

        public override IQueryable<UserProfile> GetAll()
        {
            return DbSet.Include(x => x.ExternalLinks);
        }
    }
}
