using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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
        private readonly IProfileRepositorySql profileRepository;
        private readonly IUserFollowRepositorySql userFollowRepository;
        private readonly IGameRepositorySql gameRepository;
        private readonly IGameFollowRepositorySql gameFollowRepository;
        private readonly IGameLikeRepositorySql gameLikeRepository;
        private readonly IBrainstormSessionRepositorySql brainstormSessionRepository;
        private readonly IBrainstormIdeaRepositorySql brainstormIdeaRepository;
        private readonly IBrainstormVoteRepositorySql brainstormVoteRepository;
        private readonly IBrainstormCommentRepositorySql brainstormCommentRepository;
        private readonly IUserContentRepositorySql userContentRepository;
        private readonly IUserContentLikeRepositorySql userContentLikeRepository;
        private readonly IUserContentCommentRepositorySql contentCommentRepository;
        private readonly IUserPreferencesRepositorySql userPreferencesRepository;
        private readonly IFeaturedContentRepositorySql featuredContentRepository;
        private readonly IGamificationActionRepositorySql gamificationActionRepository;
        private readonly IGamificationLevelRepositorySql gamificationLevelRepository;
        private readonly IGamificationRepositorySql gamificationRepository;
        private readonly INotificationRepositorySql notificationRepository;
        private readonly IUserBadgeRepositorySql userBadgeRepository;
        private readonly IPollRepositorySql pollRepository;
        private readonly IPollOptionRepositorySql pollOptionRepository;
        private readonly IPollVoteRepositorySql pollVoteRepository;

        public MongoMigrationController(IMongoContext context
            , IProfileRepositorySql profileRepository
            , IUserFollowRepositorySql userFollowRepository
            , IGameRepositorySql gameRepository
            , IGameFollowRepositorySql gameFollowRepository
            , IGameLikeRepositorySql gameLikeRepository
            , IBrainstormSessionRepositorySql brainstormSessionRepository
            , IBrainstormIdeaRepositorySql brainstormIdeaRepository
            , IBrainstormVoteRepositorySql brainstormVoteRepository
            , IBrainstormCommentRepositorySql brainstormCommentRepository
            , IUserContentRepositorySql userContentRepository
            , IUserContentLikeRepositorySql userContentLikeRepository
            , IUserContentCommentRepositorySql contentCommentRepository
            , IUserPreferencesRepositorySql userPreferencesRepository
            , IFeaturedContentRepositorySql featuredContentRepository
            , IGamificationActionRepositorySql gamificationActionRepository
            , IGamificationLevelRepositorySql gamificationLevelRepository
            , IGamificationRepositorySql gamificationRepository
            , INotificationRepositorySql notificationRepository
            , IUserBadgeRepositorySql userBadgeRepository
            , IPollRepositorySql pollRepository
            , IPollOptionRepositorySql pollOptionRepository
            , IPollVoteRepositorySql pollVoteRepository)
        {
            this.context = context;
            this.profileRepository = profileRepository;
            this.userFollowRepository = userFollowRepository;
            this.gameRepository = gameRepository;
            this.gameFollowRepository = gameFollowRepository;
            this.gameLikeRepository = gameLikeRepository;
            this.brainstormSessionRepository = brainstormSessionRepository;
            this.brainstormIdeaRepository = brainstormIdeaRepository;
            this.brainstormVoteRepository = brainstormVoteRepository;
            this.brainstormCommentRepository = brainstormCommentRepository;
            this.userContentRepository = userContentRepository;
            this.userContentLikeRepository = userContentLikeRepository;
            this.contentCommentRepository = contentCommentRepository;
            this.userPreferencesRepository = userPreferencesRepository;
            this.featuredContentRepository = featuredContentRepository;
            this.gamificationActionRepository = gamificationActionRepository;
            this.gamificationLevelRepository = gamificationLevelRepository;
            this.gamificationRepository = gamificationRepository;
            this.notificationRepository = notificationRepository;
            this.userBadgeRepository = userBadgeRepository;
            this.pollRepository = pollRepository;
            this.pollOptionRepository = pollOptionRepository;
            this.pollVoteRepository = pollVoteRepository;
        }

        public IActionResult Index()
        {
            var model = new List<string>
            {
                "GamificationAction",
                "GamificationLevel",
                "UserBadges",
                "UserProfiles",
                "UserPreferences",
                "Notification",
                "Gamification",
                "Games",
                "Brainstorm",
                "UserContent",
                "Polls",
                "FeaturedContent"
            };

            return View(model);
        }

        [Route("GamificationAction")]
        public IActionResult GamificationAction()
        {
            long count = 0;
            try
            {
                count = gamificationActionRepository.Count(x => true);

                var collection = context.GetCollection<GamificationAction>(typeof(GamificationAction).Name);
                collection.DeleteMany(Builders<GamificationAction>.Filter.Empty);

                var all = gamificationActionRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("GamificationLevel")]
        public IActionResult GamificationLevel()
        {
            long count = 0;
            try
            {
                count = gamificationLevelRepository.Count(x => true);

                var collection = context.GetCollection<GamificationLevel>(typeof(GamificationLevel).Name);
                collection.DeleteMany(Builders<GamificationLevel>.Filter.Empty);

                var all = gamificationLevelRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("UserBadges")]
        public IActionResult UserBadges()
        {
            long count = 0;
            try
            {
                count = userBadgeRepository.Count(x => true);

                var collection = context.GetCollection<UserBadge>(typeof(UserBadge).Name);
                collection.DeleteMany(Builders<UserBadge>.Filter.Empty);

                var all = userBadgeRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("UserProfiles")]
        public IActionResult UserProfiles()
        {
            long count = 0;
            try
            {
                count = profileRepository.Count(x => true);

                var collection = context.GetCollection<UserProfile>(typeof(UserProfile).Name);
                collection.DeleteMany(Builders<UserProfile>.Filter.Empty);

                var allFollowers = userFollowRepository.GetAll().ToList();

                var all = profileRepository.GetAll().ToList();

                foreach (var item in all)
                {
                    item.Followers = allFollowers.Where(x => x.UserId == item.UserId).ToList();
                }

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("UserPreferences")]
        public IActionResult UserPreferences()
        {
            long count = 0;
            try
            {
                count = userPreferencesRepository.Count(x => true);

                var collection = context.GetCollection<UserPreferences>(typeof(UserPreferences).Name);
                collection.DeleteMany(Builders<UserPreferences>.Filter.Empty);

                var all = userPreferencesRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("Notification")]
        public IActionResult Notification()
        {
            long count = 0;
            try
            {
                count = notificationRepository.Count(x => true);

                var collection = context.GetCollection<Notification>(typeof(Notification).Name);
                collection.DeleteMany(Builders<Notification>.Filter.Empty);

                var all = notificationRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("Games")]
        public IActionResult Games()
        {
            long count = 0;
            try
            {
                count = gameRepository.Count(x => true);

                var collection = context.GetCollection<Game>(typeof(Game).Name);
                collection.DeleteMany(Builders<Game>.Filter.Empty);

                var all = gameRepository.GetAll().ToList();
                var allFollowers = gameFollowRepository.GetAll().ToList();
                var allLikes = gameLikeRepository.GetAll().ToList();


                foreach (Game game in all)
                {
                    game.Followers = new List<GameFollow>();
                    game.Likes = new List<GameLike>();

                    var followers = allFollowers.Where(x => x.GameId == game.Id).ToList();
                    var likes = allLikes.Where(x => x.GameId == game.Id).ToList();

                    foreach (var follower in followers)
                    {
                        if (!game.Followers.Any(x => x.UserId == follower.UserId))
                        {
                            game.Followers.Add(follower);
                        }
                    }

                    foreach (var like in likes)
                    {
                        if (!game.Likes.Any(x => x.UserId == like.UserId))
                        {
                            game.Likes.Add(like);
                        }
                    }
                }

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("Brainstorm")]
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

            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("UserContent")]
        public IActionResult UserContent()
        {
            long count = 0;
            try
            {
                count = userContentRepository.Count(x => true);

                var collection = context.GetCollection<UserContent>(typeof(UserContent).Name);
                collection.DeleteMany(Builders<UserContent>.Filter.Empty);

                var all = userContentRepository.GetAll().ToList();

                foreach (var item in all)
                {
                    item.Comments = contentCommentRepository.Get(x => x.UserContentId == item.Id).ToList();
                    item.Likes = userContentLikeRepository.Get(x => x.ContentId == item.Id).ToList();
                }


                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("Polls")]
        public IActionResult Polls()
        {
            long count = 0;
            try
            {
                count = pollRepository.Count(x => true);

                var collection = context.GetCollection<Poll>(typeof(Poll).Name);
                collection.DeleteMany(Builders<Poll>.Filter.Empty);

                var all = pollRepository.GetAll().ToList();
                var allOptions = pollOptionRepository.GetAll().ToList();
                var allVotes= pollVoteRepository.GetAll().ToList();

                foreach (var poll in all)
                {
                    poll.Options = allOptions.Where(x => x.PollId == poll.Id).ToList();
                    poll.Votes = allVotes.Where(x => x.PollId == poll.Id).ToList();
                }

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("FeaturedContent")]
        public IActionResult FeaturedContent()
        {
            long count = 0;
            try
            {
                count = featuredContentRepository.Count(x => true);

                var collection = context.GetCollection<FeaturedContent>(typeof(FeaturedContent).Name);
                collection.DeleteMany(Builders<FeaturedContent>.Filter.Empty);

                var all = featuredContentRepository.GetAll().ToList();

                foreach (var item in all)
                {
                    item.EndDate = item.EndDate == DateTime.MinValue ? null : item.EndDate;
                }

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        [Route("Gamification")]
        public IActionResult Gamification()
        {
            long count = 0;
            try
            {
                count = gamificationRepository.Count(x => true);

                var collection = context.GetCollection<Domain.Models.Gamification>(typeof(Domain.Models.Gamification).Name);
                collection.DeleteMany(Builders<Domain.Models.Gamification>.Filter.Empty);

                var all = gamificationRepository.GetAll();

                collection.InsertMany(all);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return MigrationResult(count);
        }

        private IActionResult MigrationResult(long count)
        {
            var model = new KeyValuePair<string, long>(RouteData.Values["action"].ToString(), count);

            return View("~/Areas/Staff/Views/MongoMigration/MigrationResult.cshtml", model);
        }
    }
}