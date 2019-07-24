using System;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class StringExtensions
    {

        public static string GetFirstWords(this string input, int count)
        {
            return String.Join(' ', input.GetWords(count, null, StringSplitOptions.RemoveEmptyEntries));
        }

        public static string[] GetWords(
            this string input,
            int count = -1,
            string[] wordDelimiter = null,
            StringSplitOptions options = StringSplitOptions.None)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new string[] { };
            }

            if (count < 0)
            {
                return input.Split(wordDelimiter, options);
            }

            string[] words = input.Split(wordDelimiter, count + 1, options);
            if (words.Length <= count)
            {
                return words;
            }

            Array.Resize(ref words, words.Length - 1);

            return words;
        }
    }
}
