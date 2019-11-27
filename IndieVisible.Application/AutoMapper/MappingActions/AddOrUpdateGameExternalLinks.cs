using AutoMapper;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.MappingActions
{
    public class AddOrUpdateGameExternalLinks : IMappingAction<GameViewModel, Game>
    {
        public void Process(GameViewModel source, Game destination, ResolutionContext context)
        {
            List<GameExternalLink> destinationExternalLinks = new List<GameExternalLink>();

            foreach (GameExternalLinkViewModel externalLink in source.ExternalLinks)
            {
                if (externalLink.Id == Guid.Empty)
                {
                    GameExternalLink newExternalLink = context.Mapper.Map<GameExternalLink>(externalLink);
                    destinationExternalLinks.Add(newExternalLink);
                }
                else
                {
                    GameExternalLink destinationExternalLink = destination.ExternalLinks.FirstOrDefault(x => x.Id == externalLink.Id);
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