using AutoMapper;
using IndieVisible.Application.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.MappingActions
{
    public class AddOrUpdateTeamMembers : IMappingAction<TeamViewModel, Domain.Models.Team>
    {

        public void Process(TeamViewModel source, Domain.Models.Team destination, ResolutionContext context)
        {
            var destinationMembers = new List<Domain.Models.TeamMember>();

            foreach (var member in source.Members)
            {
                if (member.Id == Guid.Empty)
                {
                    var newMember = context.Mapper.Map<Domain.Models.TeamMember>(member);
                    destinationMembers.Add(newMember);
                }
                else
                {
                    var destinationMember = destination.Members.FirstOrDefault(x => x.Id == member.Id);
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
