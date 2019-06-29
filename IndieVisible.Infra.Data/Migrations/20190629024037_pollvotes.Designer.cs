﻿// <auto-generated />
using System;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IndieVisible.Infra.Data.Migrations
{
    [DbContext(typeof(IndieVisibleContext))]
    [Migration("20190629024037_pollvotes")]
    partial class pollvotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("AuthorName");

                    b.Property<string>("AuthorPicture");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("IdeaId");

                    b.Property<Guid?>("ParentCommentId");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("BrainstormComments");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormIdea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<Guid>("SessionId");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("BrainstormIdeas");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<Guid?>("TargetContextId");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BrainstormSessions");

                    b.HasData(
                        new { Id = new Guid("1fee0e42-7cfb-4438-96f9-4dbee6019de9"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Description = "Ideas for improvement on the community. This is where you can suggest new features to the community and vote for ideas from other users. This is the main mechanism to improve the community and make a place where everyone feels OK with it. Enjoy it!", Title = "IndieVisible Ideas", Type = 0, UserId = new Guid("00000000-0000-0000-0000-000000000000") }
                    );
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("IdeaId");

                    b.Property<Guid>("UserId");

                    b.Property<int>("VoteValue");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("BrainstormVotes");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.FeaturedContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Introduction")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("UserContentId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("FeaturedContents");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CoverImageUrl");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<string>("DeveloperName");

                    b.Property<int>("Engine");

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("GameDevNetUrl");

                    b.Property<string>("GameJoltUrl");

                    b.Property<int>("Genre");

                    b.Property<string>("IndieDbUrl");

                    b.Property<string>("InstagramUrl");

                    b.Property<string>("ItchIoUrl");

                    b.Property<int>("Language");

                    b.Property<string>("Platforms");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<int>("Status");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("TwitterUrl");

                    b.Property<string>("UnityConnectUrl");

                    b.Property<string>("Url");

                    b.Property<Guid>("UserId");

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.GameFollow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("GameId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("GameFollows");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.GameLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("GameId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("GameLikes");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.Gamification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CurrentLevelNumber");

                    b.Property<Guid>("UserId");

                    b.Property<int>("XpCurrentLevel");

                    b.Property<int>("XpToNextLevel");

                    b.Property<int>("XpTotal");

                    b.HasKey("Id");

                    b.ToTable("Gamifications");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.GamificationAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("Action");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ScoreValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("GamificationActions");

                    b.HasData(
                        new { Id = new Guid("f9d77561-1b39-4422-91bc-cbc9b05d8393"), Action = 1, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 5, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("72ab0038-de85-4ca0-9c38-aa9075441ee4"), Action = 2, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 10, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("10a4aa6c-5b83-44fb-b817-de60c81bc375"), Action = 3, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 10, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("c002bd0d-06ff-44de-b4aa-9d3b540cfe28"), Action = 4, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 10, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("cccbd822-5cb7-405c-8539-6ba7e2ded11f"), Action = 5, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 30, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("8b1aec66-ed4e-4d8b-85f2-fa46eda341ee"), Action = 6, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 30, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("a7139047-a7c6-4d56-a102-a9f103a75438"), Action = 7, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 30, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") },
                        new { Id = new Guid("0d607bf9-040a-48bc-8925-b423981c7daf"), Action = 8, CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), ScoreValue = 30, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891") }
                    );
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.GamificationLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.Property<Guid>("UserId");

                    b.Property<int>("XpToAchieve");

                    b.HasKey("Id");

                    b.ToTable("GamificationLevels");

                    b.HasData(
                        new { Id = new Guid("a043343c-cdf7-4c0e-a51a-cddd020d5884"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "NPC", Number = 1, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 500 },
                        new { Id = new Guid("923bfb12-ea49-442d-8f28-bf9726644264"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Idea Guy", Number = 2, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 1000 },
                        new { Id = new Guid("dbbd17a9-2114-4cf5-a723-251dc6521cad"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "I can make a GTA", Number = 3, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 2000 },
                        new { Id = new Guid("cb72c778-337f-48be-b255-86f26d086084"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Profit Sharer", Number = 4, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 3000 },
                        new { Id = new Guid("d7df851b-2a76-4640-9dc5-2de4cdcac722"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Flappy Maker", Number = 5, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 5000 },
                        new { Id = new Guid("f539bd4c-04f8-4f1a-b815-55b46d85b49b"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Tutorial Guy", Number = 6, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 10000 },
                        new { Id = new Guid("ef8220ff-f7ea-451a-a229-3435669b3854"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Asset Assembler", Number = 7, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 30000 },
                        new { Id = new Guid("929b63bf-9464-49db-8904-6b500d52082b"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Engine Ninja", Number = 8, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 60000 },
                        new { Id = new Guid("1aaaf717-4cbd-4ee3-90d3-0452e51d1a19"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "Jam Jammer", Number = 9, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 100000 },
                        new { Id = new Guid("77c72240-b6d9-49e0-885d-de202c4f9dfd"), CreateDate = new DateTime(2019, 5, 23, 0, 21, 44, 473, DateTimeKind.Local), Name = "My Studio Games", Number = 10, UserId = new Guid("0c7e18b2-3682-444d-a62b-30e311e76891"), XpToAchieve = 200000 }
                    );
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsRead");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(128);

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.Poll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("MultipleChoice")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<Guid?>("UserContentId");

                    b.Property<Guid>("UserId");

                    b.Property<bool>("UsersCanAddOptions")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.PollOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<int>("Index")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<Guid>("PollId");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.PollVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("PollId");

                    b.Property<Guid>("PollOptionId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PollOptionId");

                    b.ToTable("PollVotes");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserBadge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("Badge");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserConnection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime?>("ApprovalDate");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("TargetUserId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("AuthorName");

                    b.Property<string>("AuthorPicture");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FeaturedImage");

                    b.Property<Guid?>("GameId");

                    b.Property<string>("Introduction");

                    b.Property<int>("Language")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("UserContents");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContentComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("AuthorName");

                    b.Property<string>("AuthorPicture");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("ParentCommentId");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserContentId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContentLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid>("ContentId");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("UserContentId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserFollow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("FollowUserId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserPreferences", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentLanguages");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("UiLanguage");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Bio");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("GameDevNetUrl");

                    b.Property<string>("GameJoltUrl");

                    b.Property<string>("IndieDbUrl");

                    b.Property<string>("ItchIoUrl");

                    b.Property<string>("Location");

                    b.Property<string>("Motto");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("StudioName");

                    b.Property<int>("Type");

                    b.Property<string>("UnityConnectUrl");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormComment", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.BrainstormIdea", "Idea")
                        .WithMany("Comments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormIdea", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.BrainstormSession", "Session")
                        .WithMany("Ideas")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.BrainstormVote", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.BrainstormIdea", "Idea")
                        .WithMany("Votes")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.Poll", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.UserContent", "UserContent")
                        .WithMany("Polls")
                        .HasForeignKey("UserContentId");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.PollOption", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.PollVote", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.PollOption")
                        .WithMany("Votes")
                        .HasForeignKey("PollOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContent", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.Game", "Game")
                        .WithMany("UserContents")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContentComment", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.UserContent")
                        .WithMany("Comments")
                        .HasForeignKey("UserContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IndieVisible.Domain.Models.UserContentLike", b =>
                {
                    b.HasOne("IndieVisible.Domain.Models.UserContent")
                        .WithMany("Likes")
                        .HasForeignKey("UserContentId");
                });
#pragma warning restore 612, 618
        }
    }
}
