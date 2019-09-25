﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class GamificationAppService : IGamificationAppService
    {
        private readonly IMapper mapper;
        private readonly IGamificationDomainService gamificationDomainService;

        public Guid CurrentUserId { get; set; }

        public GamificationAppService(IMapper mapper, IGamificationDomainService gamificationDomainService)
        {
            this.mapper = mapper;
            this.gamificationDomainService = gamificationDomainService;
        }

        public OperationResultListVo<RankingViewModel> GetAll()
        {
            OperationResultListVo<RankingViewModel> result;

            try
            {
                IEnumerable<RankingVo> allModels = gamificationDomainService.Get(20);

                List<RankingViewModel> vms = new List<RankingViewModel>();

                foreach (RankingVo item in allModels)
                {
                    RankingViewModel vm = new RankingViewModel
                    {
                        UserId = item.Gamification.UserId,
                        CurrentLevelNumber = item.Gamification.CurrentLevelNumber,
                        XpCurrentLevel = item.Gamification.XpCurrentLevel,
                        XpToNextLevel = item.Gamification.XpToNextLevel,
                        XpTotal = item.Gamification.XpTotal,
                        CurrentLevelName = item.Level.Name
                    };

                    vms.Add(vm);
                }

                result = new OperationResultListVo<RankingViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<RankingViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo FillProfileGamificationDetails(Guid currentUserId, ref ProfileViewModel vm)
        {
            try
            {
                Gamification gamification = this.gamificationDomainService.GetByUserId(vm.UserId);

                GamificationLevel currentLevel = this.gamificationDomainService.GetLevel(gamification.CurrentLevelNumber);

                vm.IndieXp.LevelName = currentLevel.Name;
                vm.IndieXp.Level = gamification.CurrentLevelNumber;
                vm.IndieXp.LevelXp = gamification.XpCurrentLevel;
                vm.IndieXp.NextLevelXp = gamification.XpToNextLevel + gamification.XpCurrentLevel;

                return new OperationResultVo(true);

            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultListVo<GamificationLevelViewModel> GetAllLevels()
        {
            IQueryable<GamificationLevel> levels = gamificationDomainService.GetAllLevels().OrderBy(x => x.Number);

            var vms = levels.ProjectTo<GamificationLevelViewModel>(this.mapper.ConfigurationProvider);

            return new OperationResultListVo<GamificationLevelViewModel>(vms);
        }
    }
}
