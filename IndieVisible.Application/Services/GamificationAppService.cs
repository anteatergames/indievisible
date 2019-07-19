using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IndieVisible.Domain.Models;

namespace IndieVisible.Application.Services
{
    public class GamificationAppService : IGamificationAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGamificationDomainService gamificationDomainService;

        public Guid CurrentUserId { get; set; }

        public GamificationAppService(IMapper mapper, IUnitOfWork unitOfWork, IGamificationDomainService gamificationDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.gamificationDomainService = gamificationDomainService;
        }

        public OperationResultListVo<RankingViewModel> GetAll()
        {
            OperationResultListVo<RankingViewModel> result;

            try
            {
                IEnumerable<RankingVo> allModels = gamificationDomainService.Get(20);

                List<RankingViewModel> vms = new List<RankingViewModel>();

                foreach (var item in allModels)
                {
                    var vm = new RankingViewModel {
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
    }
}
