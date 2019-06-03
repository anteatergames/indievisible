using AutoMapper;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.AutoMapper.Resolvers
{
    public class UserLanguagesToDomainResolver : IValueResolver<UserPreferencesViewModel, UserPreferences, string>
    {
        public string Resolve(UserPreferencesViewModel source, UserPreferences destination, string destMember, ResolutionContext context)
        {
            var result = string.Empty;

            if (source.Languages == null || !source.Languages.Any())
            {
                return result;
            }

            result = string.Join('|', source.Languages);

            return result;
        }
    }

    public class UserLanguagesFromDomainResolver : IValueResolver<UserPreferences, UserPreferencesViewModel, List<SupportedLanguage>>
    {
        public List<SupportedLanguage> Resolve(UserPreferences source, UserPreferencesViewModel destination, List<SupportedLanguage> destMember, ResolutionContext context)
        {
            var platforms = (source.ContentLanguages ?? string.Empty)
                .Split(new Char[] { '|' });

            var platformsConverted = platforms.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (SupportedLanguage)Enum.Parse(typeof(SupportedLanguage), x));

            return platformsConverted.ToList();
        }
    }
}
