using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Localization
{
    public class ContributorViewModel: AuthorBaseViewModel
    {
        public int EntryCount { get; set; }
    }
}