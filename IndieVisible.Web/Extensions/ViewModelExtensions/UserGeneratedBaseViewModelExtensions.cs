using IndieVisible.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Extensions.ViewModelExtensions
{
    public static class UserGeneratedBaseViewModelExtensions
    {
        public static void SetShareUrl(this UserGeneratedBaseViewModel vm, string url)
        {
            vm.ShareUrl = url;
        }
        public static void SetShareText(this UserGeneratedBaseViewModel vm, string text)
        {
            vm.ShareText = text;
        }
    }
}
