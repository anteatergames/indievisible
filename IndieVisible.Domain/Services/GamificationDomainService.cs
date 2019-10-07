using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class GamificationDomainService : IGamificationDomainService
    {
        private readonly IGamificationRepository gamificationRepository;
        private readonly IGamificationActionRepository gamificationActionRepository;
        private readonly IGamificationLevelRepository gamificationLevelRepository;

        public GamificationDomainService(IGamificationRepository gamificationRepository, IGamificationActionRepository gamificationActionRepository, IGamificationLevelRepository gamificationLevelRepository)
        {
            this.gamificationRepository = gamificationRepository;
            this.gamificationActionRepository = gamificationActionRepository;
            this.gamificationLevelRepository = gamificationLevelRepository;
        }

        public IEnumerable<RankingVo> Get(int count)
        {
            List<RankingVo> result = new List<RankingVo>();

            List<GamificationLevel> levels = gamificationLevelRepository.GetAll().ToList();

            IQueryable<Gamification> model = gamificationRepository.GetAll().OrderByDescending(x => x.XpTotal).ThenBy(x => x.CreateDate).Take(count);

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

        public IQueryable<GamificationLevel> GetAllLevels()
        {
            IQueryable<GamificationLevel> levels = gamificationLevelRepository.GetAll();

            return levels;
        }

        public Gamification GetByUserId(Guid userId)
        {
            Gamification userGamification = gamificationRepository.GetByUserId(userId);

            if (userGamification == null)
            {
                userGamification = GenerateNewGamification(userId);

                gamificationRepository.Add(userGamification);
            }

            return userGamification;
        }

        public GamificationLevel GetLevel(int levelNumber)
        {
            GamificationLevel level = gamificationLevelRepository.GetByNumber(levelNumber);

            return level;
        }

        public int ProcessAction(Guid userId, PlatformAction action)
        {
            GamificationAction actionToProcess = gamificationActionRepository.GetByAction(action);

            Gamification userGamification = gamificationRepository.GetByUserId(userId);

            if (userGamification == null)
            {
                GamificationLevel newLevel = gamificationLevelRepository.GetByNumber(1);

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
                    GamificationLevel currentLevel = gamificationLevelRepository.GetByNumber(userGamification.CurrentLevelNumber);
                    GamificationLevel newLevel = gamificationLevelRepository.GetByNumber(userGamification.CurrentLevelNumber + 1);

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
            GamificationLevel firstLevel = gamificationLevelRepository.GetByNumber(1);

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
