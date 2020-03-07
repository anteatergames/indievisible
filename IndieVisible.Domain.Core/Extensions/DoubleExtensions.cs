using System.Globalization;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToInvariant(this double number)
        {
            return number.ToString("###.#", CultureInfo.InvariantCulture);
        }
    }
}
