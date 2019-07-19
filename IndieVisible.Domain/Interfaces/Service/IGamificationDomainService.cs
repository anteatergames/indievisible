using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGamificationDomainService
    {
        IEnumerable<RankingVo> Get(int count);
        void ProcessAction(Guid userId, PlatformAction action);
        GamificationLevel GetLevel(int levelNumber);
        Gamification GetByUserId(Guid userId);
    }
}
