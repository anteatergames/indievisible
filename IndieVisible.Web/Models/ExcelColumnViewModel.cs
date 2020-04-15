using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;

namespace IndieVisible.Web.Models
{
    public class ExcelColumnViewModel
    {
        public int Column { get; set; }
        public SupportedLanguage Language { get; set; }
    }

    public static class ExcelColumnViewModelExtensions
    {

        public static IEnumerable<KeyValuePair<int, SupportedLanguage>> ToKeyValuePairs(this IEnumerable<ExcelColumnViewModel> list)
        {
            List<KeyValuePair<int, SupportedLanguage>> kvList = new List<KeyValuePair<int, SupportedLanguage>>();

            foreach (ExcelColumnViewModel item in list)
            {
                if (item.Language != 0)
                {
                    kvList.Add(new KeyValuePair<int, SupportedLanguage>(item.Column, item.Language));
                }
            }

            return kvList;
        }
    }
}

