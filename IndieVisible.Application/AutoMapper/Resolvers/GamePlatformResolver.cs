using AutoMapper;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.Resolvers
{
    public class GamePlatformToDomainResolver : IValueResolver<GameViewModel, Game, string>
    {
        public string Resolve(GameViewModel source, Game destination, string destMember, ResolutionContext context)
        {
            var result = string.Empty;

            if (source.Platforms == null || !source.Platforms.Any())
            {
                return result;
            }

            result = string.Join('|', source.Platforms);

            return result;
        }
    }

    public class GamePlatformFromDomainResolver : IValueResolver<Game, GameViewModel, List<GamePlatforms>>
    {
        public List<GamePlatforms> Resolve(Game source, GameViewModel destination, List<GamePlatforms> destMember, ResolutionContext context)
        {
            var platforms = (source.Platforms ?? string.Empty)
                .Replace("XboxOne", "Xbox")
                .Replace("Playstation4", "Playstation")
                .Split(new Char[] { '|' });

            var platformsConverted = platforms.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (GamePlatforms)Enum.Parse(typeof(GamePlatforms), x));

            return platformsConverted.ToList();
        }
    }
}
