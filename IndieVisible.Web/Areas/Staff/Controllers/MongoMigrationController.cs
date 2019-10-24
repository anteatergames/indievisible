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
                collection.DeleteMany(Builders<UserProfile>.Filter.Empty);

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
                collection.DeleteMany(Builders<Game>.Filter.Empty);

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
                var collectionSessions = context.GetCollection<BrainstormSession>(typeof(BrainstormSession).Name);
                var collectionIdeas = context.GetCollection<BrainstormIdea>(typeof(BrainstormIdea).Name);
                var collectionVotes = context.GetCollection<BrainstormVote>(typeof(BrainstormVote).Name);
                var collectionComments = context.GetCollection<BrainstormComment>(typeof(BrainstormComment).Name);


                collectionComments.DeleteMany(Builders<BrainstormComment>.Filter.Empty);
                collectionVotes.DeleteMany(Builders<BrainstormVote>.Filter.Empty);
                collectionIdeas.DeleteMany(Builders<BrainstormIdea>.Filter.Empty);
                collectionSessions.DeleteMany(Builders<BrainstormSession>.Filter.Empty);

                var allSessions = brainstormSessionRepository.GetAll().ToList();
                var firstSession = allSessions.First();
                foreach (var session in allSessions)
                {
                    session.Ideas = null;
                }
                count += allSessions.Count();
                collectionSessions.InsertMany(allSessions);

                var allIdeas = brainstormIdeaRepository.GetAll().ToList();
                foreach (var idea in allIdeas)
                {
                    idea.Session = null;
                    idea.Votes = null;
                    idea.Comments = null;
                }
                count += allIdeas.Count();
                collectionIdeas.InsertMany(allIdeas);

                var allVotes = brainstormVoteRepository.GetAll().ToList();
                foreach (var vote in allVotes)
                {
                    vote.Idea = null;
                    vote.SessionId = firstSession.Id;
                }
                count += allVotes.Count();
                collectionVotes.InsertMany(allVotes);

                var allComments = brainstormCommentRepository.GetAll().ToList();
                foreach (var comment in allComments)
                {
                    comment.Idea = null;
                    comment.SessionId = firstSession.Id;
                }
                count += allComments.Count();
                collectionComments.InsertMany(allComments);


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