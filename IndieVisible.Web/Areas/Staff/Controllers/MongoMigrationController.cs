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
using MongoDB.Driver;

namespace IndieVisible.Web.Areas.Staff.Controllers
{
    [Area("staff")]
    [Route("admin/mongomigration")]
    public class MongoMigrationController : SecureBaseController
    {
        private readonly IMongoContext context;
        private readonly IProfileRepository profileRepository;
        private readonly IGameRepository gameRepository;
        private readonly IBrainstormSessionRepository brainstormSessionRepository;
        private readonly IBrainstormIdeaRepository brainstormIdeaRepository;
        private readonly IBrainstormVoteRepository brainstormVoteRepository;
        private readonly IBrainstormCommentRepository brainstormCommentRepository;

        public MongoMigrationController(IMongoContext context
            , IProfileRepository profileRepository
            , IGameRepository gameRepository
            , IBrainstormSessionRepository brainstormSessionRepository
            , IBrainstormIdeaRepository brainstormIdeaRepository
            , IBrainstormVoteRepository brainstormVoteRepository
            , IBrainstormCommentRepository brainstormCommentRepository)
        {
            this.context = context;
            this.profileRepository = profileRepository;
            this.gameRepository = gameRepository;
            this.brainstormSessionRepository = brainstormSessionRepository;
            this.brainstormIdeaRepository = brainstormIdeaRepository;
            this.brainstormVoteRepository = brainstormVoteRepository;
            this.brainstormCommentRepository = brainstormCommentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("profiles")]
        public IActionResult Profiles()
        {
            long count = 0;
            try
            {
                count = profileRepository.Count(x => true);

                var collection = context.GetCollection<UserProfile>(typeof(UserProfile).Name);

                var all = profileRepository.GetAll();

                collection.InsertMany(all);

                var model = new KeyValuePair<string, long>("UserProfile", count);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;

                var model = new KeyValuePair<string, long>("UserProfile", 0);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
        }

        [Route("games")]
        public IActionResult Games()
        {
            long count = 0;
            try
            {
                count = gameRepository.Count(x => true);

                var collection = context.GetCollection<Game>(typeof(Game).Name);

                var all = gameRepository.GetAll();

                collection.InsertMany(all);

                var model = new KeyValuePair<string, long>("Game", count);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;

                var model = new KeyValuePair<string, long>("UserProfile", 0);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
        }

        [Route("brainstorm")]
        public IActionResult Brainstorm()
        {
            long count = 0;
            try
            {
                count = brainstormSessionRepository.Count(x => true);

                var collection = context.GetCollection<BrainstormSession>(typeof(BrainstormSession).Name);

                var all = brainstormSessionRepository.GetAll();

                foreach (var session in all)
                {
                    session.Ideas = brainstormIdeaRepository.Get(x => x.SessionId == session.Id).ToList();

                    foreach (var idea in session.Ideas)
                    {
                        idea.Session = null;

                        idea.Votes = brainstormVoteRepository.Get(x => x.IdeaId == idea.Id).ToList();

                        foreach (var vote in idea.Votes)
                        {
                            vote.Idea = null;
                        }


                        idea.Comments = brainstormCommentRepository.Get(x => x.IdeaId == idea.Id).ToList();

                        foreach (var comment in idea.Comments)
                        {
                            comment.Idea = null;
                        }
                    }
                }

                collection.InsertMany(all);

                var model = new KeyValuePair<string, long>("Brainstorm Session", count);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;

                var model = new KeyValuePair<string, long>("UserProfile", 0);

                return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
            }
        }
    }
}