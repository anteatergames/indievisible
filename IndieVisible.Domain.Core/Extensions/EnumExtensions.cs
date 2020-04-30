using IndieVisible.Domain.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());

            if (memInfo == null || memInfo.Length == 0)
            {
                return null;
            }
            else
            {
                object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

                if (attributes == null || attributes.Length == 0)
                {
                    return null;
                }

                return (T)attributes[0];
            }
        }

        public static Dictionary<string, string> ToDictionary<TEnum>(this TEnum enumeration) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            List<KeyValuePair<string, string>> dict = new List<KeyValuePair<string, string>>();

            IEnumerable<TEnum> enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            enumValues.ToList().ForEach(x =>
            {
                string uiClass = x.GetAttributeOfType<UiInfoAttribute>().Class;

                dict.Add(new KeyValuePair<string, string>(x.ToString(), uiClass));
            });

            Dictionary<string, string> result = dict.ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public static Dictionary<string, string> ToDisplayNameList<TEnum>(this IEnumerable<TEnum> enumeration) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            List<KeyValuePair<string, string>> dict = new List<KeyValuePair<string, string>>();

            enumeration.ToList().ForEach(x =>
            {
                dict.Add(new KeyValuePair<string, string>(x.ToString(), x.ToDisplayName()));
            });

            Dictionary<string, string> result = dict.ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public static string ToDisplayName<TEnum>(this TEnum enumeration) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            DisplayAttribute display = enumeration.GetAttributeOfType<DisplayAttribute>();

            if (display == null)
            {
                return enumeration.ToString();
            }
            else
            {
                return display.Name;
            }
        }

        public static Dictionary<TEnum, UiInfoAttribute> ToUiInfoDictionary<TEnum>(this IEnumerable<TEnum> enumeration) where TEnum : Enum
        {
            return ToUiInfoDictionary(enumeration, false);
        }

        public static Dictionary<TEnum, UiInfoAttribute> ToUiInfoDictionary<TEnum>(this IEnumerable<TEnum> enumeration, bool randomize) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            Dictionary<TEnum, UiInfoAttribute> dict = new Dictionary<TEnum, UiInfoAttribute>();

            var genreList = enumeration.ToList();

            if (randomize)
            {
                genreList.Shuffle(); 
            }

            genreList.ForEach(x =>
            {
                dict.Add(x, x.ToUiInfo());
            });

            return dict;
        }

        public static UiInfoAttribute ToUiInfo<TEnum>(this TEnum enumeration) where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            UiInfoAttribute uiInfo = enumeration.GetAttributeOfType<UiInfoAttribute>();

            if (uiInfo == null)
            {
                return new UiInfoAttribute
                {
                    Display = enumeration.ToString()
                };
            }
            else
            {
                return uiInfo;
            }
        }
    }
}