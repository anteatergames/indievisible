using AutoMapper;
using IndieVisible.Application.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Application.AutoMapper.MappingActions
{
    public class AddOrUpdateTeamMembers : IMappingAction<TeamViewModel, Domain.Models.Team>
    {

        public void Process(TeamViewModel source, Domain.Models.Team destination, ResolutionContext context)
        {
            if (destination.Members == null)
            {
                destination.Members = new List<Domain.Models.TeamMember>();
            }

            foreach (var member in source.Members)
            {
                if (member.Id == Guid.Empty)
                {
                    var newMember = context.Mapper.Map<Domain.Models.TeamMember>(member);
                    destination.Members.Add(newMember);
                }
                else
                {
                    var destinationMember = destination.Members.FirstOrDefault(x => x.Id == member.Id);
                    if (destinationMember != null)
                    {
                        destinationMember = context.Mapper.Map(member, destinationMember);
                    }
                }
            }
        }
    }
}
