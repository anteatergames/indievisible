using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class GamificationDomainService : IGamificationDomainService
    {
        private readonly IGamificationRepository gamificationRepository;
        private readonly IGamificationActionRepository gamificationActionRepository;
        private readonly IGamificationLevelRepository gamificationLevelRepository;
        private readonly IUserBadgeRepository userBadgeRepository;

        public GamificationDomainService(IGamificationRepository gamificationRepository
            , IGamificationActionRepository gamificationActionRepository
            , IGamificationLevelRepository gamificationLevelRepository
            , IUserBadgeRepository userBadgeRepository)
        {
            this.gamificationRepository = gamificationRepository;
            this.gamificationActionRepository = gamificationActionRepository;
            this.gamificationLevelRepository = gamificationLevelRepository;
            this.userBadgeRepository = userBadgeRepository;
        }

        #region Gamification
        public IEnumerable<RankingVo> Get(int count)
        {
            List<RankingVo> result = new List<RankingVo>();

            List<GamificationLevel> levels = gamificationLevelRepository.Get().ToList();

            IQueryable<Gamification> model = gamificationRepository.Get().OrderByDescending(x => x.XpTotal).ThenBy(x => x.CreateDate).Take(count);

            List<Gamification> list = model.ToList();

            foreach (Gamification item in list)
            {
                RankingVo newVo = new RankingVo
                {
                    Gamification = item,
                    Level = levels.FirstOrDefault(x => x.Number == item.CurrentLevelNumber)
                };

                result.Add(newVo);
            }

            return result;
        }

        public Gamification GetByUserId(Guid userId)
        {
            var userGamificationTask = gamificationRepository.GetByUserId(userId);

            userGamificationTask.Wait();

            var userGamification = userGamificationTask.Result.FirstOrDefault();

            if (userGamification == null)
            {
                userGamification = GenerateNewGamification(userId);

                gamificationRepository.Add(userGamification);
            }

            return userGamification;
        }
        #endregion

        #region Levels
        public IQueryable<GamificationLevel> GetAllLevels()
        {
            IQueryable<GamificationLevel> levels = gamificationLevelRepository.Get();

            return levels;
        }

        public GamificationLevel GetLevel(int levelNumber)
        {
            var task = Task.Run(async () => await gamificationLevelRepository.GetByNumber(levelNumber));

            return task.Result;
        }
        #endregion

        #region Badges
        public IEnumerable<UserBadge> GetBadges()
        {
            IQueryable<UserBadge> model = userBadgeRepository.Get();

            return model;
        }

        public UserBadge GetBadgeById(Guid id)
        {
            var task = userBadgeRepository.GetById(id);
            task.Wait();
            return task.Result;
        }

        public IEnumerable<UserBadge> GetBadgesByUserId(Guid userId)
        {
            var task = userBadgeRepository.GetByUserId(userId);
            task.Wait();
            return task.Result;
        }
        #endregion

        public int ProcessAction(Guid userId, PlatformAction action)
        {
            var actionToProcess = Task.Run(async () => await gamificationActionRepository.GetByAction(action)).Result;

            var userGamificationTask = gamificationRepository.GetByUserId(userId);

            userGamificationTask.Wait();

            var userGamification = userGamificationTask.Result.FirstOrDefault();

            if (userGamification == null)
            {
                GamificationLevel newLevel = Task.Run(async () => await gamificationLevelRepository.GetByNumber(1)).Result;

                userGamification = GenerateNewGamification(userId);

                userGamification.XpCurrentLevel += actionToProcess.ScoreValue;
                userGamification.XpTotal += actionToProcess.ScoreValue;
                userGamification.XpToNextLevel = (newLevel.XpToAchieve - actionToProcess.ScoreValue);

                gamificationRepository.Add(userGamification);
            }
            else
            {
                userGamification.XpCurrentLevel += actionToProcess.ScoreValue;
                userGamification.XpTotal += actionToProcess.ScoreValue;
                userGamification.XpToNextLevel -= actionToProcess.ScoreValue;

                if (userGamification.XpToNextLevel <= 0)
                {
                    GamificationLevel currentLevel = Task.Run(async () => await gamificationLevelRepository.GetByNumber(userGamification.CurrentLevelNumber)).Result;
                    GamificationLevel newLevel = Task.Run(async () => await gamificationLevelRepository.GetByNumber(userGamification.CurrentLevelNumber + 1)).Result;

                    if (newLevel != null)
                    {
                        userGamification.CurrentLevelNumber = newLevel.Number;
                        userGamification.XpCurrentLevel = (userGamification.XpCurrentLevel - currentLevel.XpToAchieve);
                        userGamification.XpToNextLevel = (newLevel.XpToAchieve - userGamification.XpCurrentLevel);
                    }
                }

                gamificationRepository.Update(userGamification);
            }

            return actionToProcess.ScoreValue;
        }

        private Gamification GenerateNewGamification(Guid userId)
        {
            Gamification userGamification;

            GamificationLevel firstLevel = Task.Run(async () => await gamificationLevelRepository.GetByNumber(1)).Result;

            userGamification = new Gamification
            {
                CurrentLevelNumber = firstLevel.Number,
                UserId = userId,
                XpCurrentLevel = 0,
                XpToNextLevel = firstLevel.XpToAchieve,
                XpTotal = 0
            };

            return userGamification;
        }
    }
}
