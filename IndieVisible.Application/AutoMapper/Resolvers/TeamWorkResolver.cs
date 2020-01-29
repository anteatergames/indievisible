using AutoMapper;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.Resolvers
{
    public class TeamWorkToDomainResolver : IValueResolver<TeamMemberViewModel, TeamMember, string>
    {
        public string Resolve(TeamMemberViewModel source, TeamMember destination, string destMember, ResolutionContext context)
        {
            string result = string.Empty;

            if (source.Works == null || !source.Works.Any())
            {
                return result;
            }

            result = string.Join('|', source.Works);

            return result;
        }
    }

    public class TeamWorkFromDomainResolver : IValueResolver<TeamMember, TeamMemberViewModel, List<WorkType>>
    {
        public List<WorkType> Resolve(TeamMember source, TeamMemberViewModel destination, List<WorkType> destMember, ResolutionContext context)
        {
            string[] platforms = (source.Work ?? string.Empty)
                .Split(new Char[] { '|' });

            IEnumerable<WorkType> platformsConverted = platforms.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (WorkType)Enum.Parse(typeof(WorkType), x));

            return platformsConverted.ToList();
        }
    }
}