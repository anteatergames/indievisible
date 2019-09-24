using IndieVisible.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IndieVisible.Web.Extensions
{
    public static class IEnumerableExtensions
    {
        public static List<SelectListItem> ToSelectList(this IEnumerable<SelectListItemVo> items)
        {
            List<SelectListItem> finalList = new List<SelectListItem>();

            foreach (var item in items)
            {
                var sli = new SelectListItem
                {
                    Value = item.Value,
                    Text = item.Text
                };

                finalList.Add(sli);
            }

            return finalList;
        }
    }
}
