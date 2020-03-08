using System.Globalization;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToInvariant(this double number)
        {
            if (number == 0)
            {
                return "0";
            }

            return number.ToString("###.#", CultureInfo.InvariantCulture);
        }
    }
}
