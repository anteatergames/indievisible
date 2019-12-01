using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGamificationDomainService
    {
        #region Gamification

        IEnumerable<RankingVo> Get(int count);

        Gamification GetByUserId(Guid userId);

        #endregion Gamification

        #region Levels

        GamificationLevel GetLevel(int levelNumber);

        IQueryable<GamificationLevel> GetAllLevels();

        #endregion Levels

        #region UserBadges

        IEnumerable<UserBadge> GetBadges();

        UserBadge GetBadgeById(Guid id);

        IEnumerable<UserBadge> GetBadgesByUserId(Guid userId);

        #endregion UserBadges

        int ProcessAction(Guid userId, PlatformAction action);
    }
}