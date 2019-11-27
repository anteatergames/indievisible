using AutoMapper;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.MappingActions
{
    public class AddOrUpdateTeamMembers : IMappingAction<TeamViewModel, Team>
    {
        public void Process(TeamViewModel source, Team destination, ResolutionContext context)
        {
            List<TeamMember> destinationMembers = new List<TeamMember>();

            foreach (TeamMemberViewModel member in source.Members)
            {
                if (member.Id == Guid.Empty)
                {
                    TeamMember newMember = context.Mapper.Map<TeamMember>(member);
                    destinationMembers.Add(newMember);
                }
                else
                {
                    TeamMember destinationMember = destination.Members.FirstOrDefault(x => x.Id == member.Id);
                    if (destinationMember != null)
                    {
                        context.Mapper.Map(member, destinationMember);
                        destinationMembers.Add(destinationMember);
                    }
                }
            }

            destination.Members = destinationMembers;
        }
    }
}