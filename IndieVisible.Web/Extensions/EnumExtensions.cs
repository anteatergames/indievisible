using IndieVisible.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string ToJson<TEnum>(this TEnum enumeration) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            StringBuilder sb = new StringBuilder();

            IEnumerable<TEnum> enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            sb.Append("{ ");

            for (int i = 0; i < enumValues.Count(); i++)
            {
                TEnum item = enumValues.ElementAt(i);

                Domain.Core.Attributes.UiInfoAttribute ui = item.ToUiInfo();

                string text = String.Format("\"{0}\": \"{1}\"", Convert.ToInt32(item), ui.Display);

                sb.Append(text);

                if (i < enumValues.Count() - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append(" }");

            return sb.ToString();
        }
    }
}
