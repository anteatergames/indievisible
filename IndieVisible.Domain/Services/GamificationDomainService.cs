using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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
            Task<IEnumerable<Gamification>> userGamificationTask = gamificationRepository.GetByUserId(userId);

            userGamificationTask.Wait();

            Gamification userGamification = userGamificationTask.Result.FirstOrDefault();

            if (userGamification == null)
            {
                userGamification = GenerateNewGamification(userId);

                gamificationRepository.Add(userGamification);
            }

            return userGamification;
        }

        #endregion Gamification

        #region Levels

        public IQueryable<GamificationLevel> GetAllLevels()
        {
            IQueryable<GamificationLevel> levels = gamificationLevelRepository.Get();

            return levels;
        }

        public GamificationLevel GetLevel(int levelNumber)
        {
            Task<GamificationLevel> task = Task.Run(async () => await gamificationLevelRepository.GetByNumber(levelNumber));

            return task.Result;
        }

        #endregion Levels

        #region Badges

        public IEnumerable<UserBadge> GetBadges()
        {
            IQueryable<UserBadge> model = userBadgeRepository.Get();

            return model;
        }

        public UserBadge GetBadgeById(Guid id)
        {
            Task<UserBadge> task = userBadgeRepository.GetById(id);
            task.Wait();
            return task.Result;
        }

        public IEnumerable<UserBadge> GetBadgesByUserId(Guid userId)
        {
            Task<IEnumerable<UserBadge>> task = userBadgeRepository.GetByUserId(userId);
            task.Wait();
            return task.Result;
        }

        #endregion Badges

        public int ProcessAction(Guid userId, PlatformAction action)
        {
            int scoreValue = 5;
            GamificationAction actionToProcess = Task.Run(async () => await gamificationActionRepository.GetByAction(action)).Result;

            if (actionToProcess != null)
            {
                scoreValue = actionToProcess.ScoreValue;
            }

            Task<IEnumerable<Gamification>> userGamificationTask = gamificationRepository.GetByUserId(userId);

            userGamificationTask.Wait();

            Gamification userGamification = userGamificationTask.Result.FirstOrDefault();

            if (userGamification == null)
            {
                GamificationLevel newLevel = Task.Run(async () => await gamificationLevelRepository.GetByNumber(1)).Result;

                userGamification = GenerateNewGamification(userId);

                userGamification.XpCurrentLevel += scoreValue;
                userGamification.XpTotal += scoreValue;
                userGamification.XpToNextLevel = (newLevel.XpToAchieve - scoreValue);

                gamificationRepository.Add(userGamification);
            }
            else
            {
                userGamification.XpCurrentLevel += scoreValue;
                userGamification.XpTotal += scoreValue;
                userGamification.XpToNextLevel -= scoreValue;

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

            return scoreValue;
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