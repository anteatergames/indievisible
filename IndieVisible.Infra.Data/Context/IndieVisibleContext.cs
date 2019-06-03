using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace IndieVisible.Infra.Data.Context
{
    public class IndieVisibleContext : DbContext
    {
        public IConfiguration Configuration { get; }

        #region Platform
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        #endregion

        public DbSet<FeaturedContent> FeaturedContents { get; set; }


        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<UserFollow> Follows { get; set; }
        public DbSet<UserConnection> Connections { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameLike> GameLikes { get; set; }
        public DbSet<GameFollow> GameFollows { get; set; }

        public DbSet<UserContent> UserContents { get; set; }
        public DbSet<UserContentLike> Likes { get; set; }
        public DbSet<UserContentComment> Comments { get; set; }

        #region Brainstorm
        public DbSet<BrainstormSession> BrainstormSessions { get; set; }
        public DbSet<BrainstormIdea> BrainstormIdeas { get; set; }
        public DbSet<BrainstormVote> BrainstormVotes { get; set; }
        public DbSet<BrainstormComment> BrainstormComments { get; set; }
        #endregion


        #region Gamification
        public DbSet<Gamification> Gamifications { get; set; }
        public DbSet<GamificationAction> GamificationActions { get; set; }
        public DbSet<GamificationLevel> GamificationLevels { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        #endregion


        public IndieVisibleContext()
        {

        }

        public IndieVisibleContext(DbContextOptions<IndieVisibleContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationConfig());

            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new GameLikeConfig());
            modelBuilder.ApplyConfiguration(new GameFollowConfig());

            modelBuilder.ApplyConfiguration(new ProfileConfig());
            modelBuilder.ApplyConfiguration(new UserFollowConfig());
            modelBuilder.ApplyConfiguration(new UserConnectionConfig());

            modelBuilder.ApplyConfiguration(new UserContentConfig());
            modelBuilder.ApplyConfiguration(new UserContentLikeConfig());
            modelBuilder.ApplyConfiguration(new UserContentCommentConfig());

            modelBuilder.ApplyConfiguration(new FeaturedContentConfig());

            #region Brainstorm
            modelBuilder.ApplyConfiguration(new BrainstormSessionConfig());
            modelBuilder.ApplyConfiguration(new BrainstormIdeaConfig());
            modelBuilder.ApplyConfiguration(new BrainstormVoteConfig());
            modelBuilder.ApplyConfiguration(new BrainstormCommentConfig());
            #endregion


            #region Gamification
            modelBuilder.ApplyConfiguration(new GamificationConfig());
            modelBuilder.ApplyConfiguration(new GamificationActionConfig());
            modelBuilder.ApplyConfiguration(new GamificationLevelConfig());
            modelBuilder.ApplyConfiguration(new UserBadgeConfig());
            #endregion

            base.OnModelCreating(modelBuilder);

            this.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();


            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("IndieVisible.Infra.Data"));
        }

        private void Seed(ModelBuilder builder)
        {

            builder.Entity<BrainstormSession>().HasData(new BrainstormSession
            {
                Id = new Guid("1FEE0E42-7CFB-4438-96F9-4DBEE6019DE9"),
                Title = "IndieVisible Ideas",
                Description = "Ideas for improvement on the community. This is where you can suggest new features to the community and vote for ideas from other users. This is the main mechanism to improve the community and make a place where everyone feels OK with it. Enjoy it!",
                Type = BrainstormSessionType.Main,
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local)
            });

            SeedGamificationActions(builder);
            SeedGamificationLevels(builder);
        }

        private static void SeedGamificationActions(ModelBuilder builder)
        {
            builder.Entity<GamificationAction>().HasData(new GamificationAction
            {
                Id = new Guid("F9D77561-1B39-4422-91BC-CBC9B05D8393"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.SimplePost,
                ScoreValue = 5
            }, new GamificationAction
            {
                Id = new Guid("72AB0038-DE85-4CA0-9C38-AA9075441EE4"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.ComplexPost,
                ScoreValue = 10
            }, new GamificationAction
            {
                Id = new Guid("10A4AA6C-5B83-44FB-B817-DE60C81BC375"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.GameAdd,
                ScoreValue = 10
            }, new GamificationAction
            {
                Id = new Guid("C002BD0D-06FF-44DE-B4AA-9D3B540CFE28"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.IdeaSuggested,
                ScoreValue = 10
            }, new GamificationAction
            {
                Id = new Guid("CCCBD822-5CB7-405C-8539-6BA7E2DED11F"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.IdeaImplemented,
                ScoreValue = 30
            }, new GamificationAction
            {
                Id = new Guid("8B1AEC66-ED4E-4D8B-85F2-FA46EDA341EE"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.PopularPost,
                ScoreValue = 30
            }, new GamificationAction
            {
                Id = new Guid("A7139047-A7C6-4D56-A102-A9F103A75438"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.PostFeatured,
                ScoreValue = 30
            }, new GamificationAction
            {
                Id = new Guid("0D607BF9-040A-48BC-8925-B423981C7DAF"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Action = PlatformAction.GameFeatured,
                ScoreValue = 30
            });
        }
        private static void SeedGamificationLevels(ModelBuilder builder)
        {
            builder.Entity<GamificationLevel>().HasData(new GamificationLevel
            {
                Id = new Guid("A043343C-CDF7-4C0E-A51A-CDDD020D5884"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 1,
                Name = "NPC",
                XpToAchieve = 500
            }, new GamificationLevel
            {
                Id = new Guid("923BFB12-EA49-442D-8F28-BF9726644264"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 2,
                Name = "Idea Guy",
                XpToAchieve = 1000
            }, new GamificationLevel
            {
                Id = new Guid("DBBD17A9-2114-4CF5-A723-251DC6521CAD"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 3,
                Name = "I can make a GTA",
                XpToAchieve = 2000
            }, new GamificationLevel
            {
                Id = new Guid("CB72C778-337F-48BE-B255-86F26D086084"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 4,
                Name = "Profit Sharer",
                XpToAchieve = 3000
            }, new GamificationLevel
            {
                Id = new Guid("D7DF851B-2A76-4640-9DC5-2DE4CDCAC722"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 5,
                Name = "Flappy Maker",
                XpToAchieve = 5000
            }, new GamificationLevel
            {
                Id = new Guid("F539BD4C-04F8-4F1A-B815-55B46D85B49B"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 6,
                Name = "Tutorial Guy",
                XpToAchieve = 10000
            }, new GamificationLevel
            {
                Id = new Guid("EF8220FF-F7EA-451A-A229-3435669B3854"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 7,
                Name = "Asset Assembler",
                XpToAchieve = 30000
            }, new GamificationLevel
            {
                Id = new Guid("929B63BF-9464-49DB-8904-6B500D52082B"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 8,
                Name = "Engine Ninja",
                XpToAchieve = 60000
            }, new GamificationLevel
            {
                Id = new Guid("1AAAF717-4CBD-4EE3-90D3-0452E51D1A19"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 9,
                Name = "Jam Jammer",
                XpToAchieve = 100000
            }, new GamificationLevel
            {
                Id = new Guid("77C72240-B6D9-49E0-885D-DE202C4F9DFD"),
                UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"),
                CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local),
                Number = 10,
                Name = "My Studio Games",
                XpToAchieve = 200000
            });
        }
    }
}