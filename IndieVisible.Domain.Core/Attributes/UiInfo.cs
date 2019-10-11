using System;

namespace IndieVisible.Domain.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class UiInfoAttribute : Attribute
    {
        public int Order { get; set; }
        public string Class { get; set; }
        public string Culture { get; set; }
        public string Description { get; set; }
        public string Display { get; set; }
        public object Type { get; set; }
    }
}
