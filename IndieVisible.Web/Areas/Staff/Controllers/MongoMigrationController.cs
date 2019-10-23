using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Staff.Controllers
{
    [Route("admin/mongomigration")]
    public class MongoMigrationController : SecureBaseController
    {
        private readonly IMongoContext context;
        private readonly IProfileAppService profileAppService;
        private readonly IProfileDomainService profileDomainService;
        private readonly IGameRepository gameRepository;

        public MongoMigrationController(IMongoContext context
            , IProfileAppService profileAppService
            , IProfileDomainService profileDomainService
            , IGameRepository gameRepository)
        {
            this.context = context;
            this.profileAppService = profileAppService;
            this.profileDomainService = profileDomainService;
            this.gameRepository = gameRepository;
        }

        [Route("profiles")]
        public string Profiles()
        {
            long total = 0;
            var count = 0;
            try
            {
                total = profileAppService.Count(this.CurrentUserId).Value;

                var collection = context.GetCollection<UserProfile>(typeof(UserProfile).Name);

                var all = profileDomainService.GetAll().ToList();

                collection.InsertMany(all);

                return String.Format("Migrated = {0}/{1}", count, total);
            }
            catch (Exception ex)
            {
                return String.Format("Migrated = {0}/{1}", count, total);
            }
        }

        [Route("games")]
        public string Games()
        {
            var total = 0;
            var count = 0;
            try
            {
                total = gameRepository.Count(x => true);

                var collection = context.GetCollection<Game>(typeof(Game).Name);

                var all = gameRepository.GetAll();

                collection.InsertMany(all);

                return String.Format("Migrated = {0}/{1}", count, total);
            }
            catch (Exception ex)
            {
                return String.Format("Migrated = {0}/{1}", count, total);
            }
        }
    }
}