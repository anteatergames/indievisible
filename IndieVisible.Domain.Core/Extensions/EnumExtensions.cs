using System;
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

            if (memInfo == null)
            {
                return null;
            }
            else {
                object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
                return (attributes.Length > 0) ? (T)attributes[0] : null; 
            }
        }
    }
}
