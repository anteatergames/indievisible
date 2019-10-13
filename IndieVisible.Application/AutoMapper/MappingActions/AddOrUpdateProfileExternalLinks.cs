using AutoMapper;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.MappingActions
{
    public class AddOrUpdateProfileExternalLinks : IMappingAction<ProfileViewModel, UserProfile>
    {
        public void Process(ProfileViewModel source, UserProfile destination, ResolutionContext context)
        {
            List<UserProfileExternalLink> destinationExternalLinks = new List<UserProfileExternalLink>();

            foreach (UserProfileExternalLinkViewModel externalLink in source.ExternalLinks)
            {
                if (externalLink.Id == Guid.Empty)
                {
                    UserProfileExternalLink newExternalLink = context.Mapper.Map<UserProfileExternalLink>(externalLink);
                    destinationExternalLinks.Add(newExternalLink);
                }
                else
                {
                    UserProfileExternalLink destinationExternalLink = destination.ExternalLinks.FirstOrDefault(x => x.Id == externalLink.Id);
                    if (destinationExternalLink != null)
                    {
                        context.Mapper.Map(externalLink, destinationExternalLink);
                        destinationExternalLinks.Add(destinationExternalLink);
                    }
                }
            }

            destination.ExternalLinks = destinationExternalLinks;
        }
    }
}
