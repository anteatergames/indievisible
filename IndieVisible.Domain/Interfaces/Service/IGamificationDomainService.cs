using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGamificationDomainService
    {
        void ProcessAction(Guid userId, PlatformAction action);
        Gamification GetGamificationByUserId(Guid userId);
        GamificationLevel GetLevel(int levelNumber);
    }
}
