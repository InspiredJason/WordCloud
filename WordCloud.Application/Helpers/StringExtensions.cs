using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCloud.Application.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes characters from a given string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="stopChars"></param>
        /// <returns></returns>
        public static string RemoveIllegalChars(this string input, string[] stopChars)
        {
            foreach (var c in stopChars)
            {
                input = input.Replace(c, string.Empty);
            }
            return input;
        }

        /// <summary>
        /// Removes a list of words from the input list
        /// </summary>
        /// <param name="input"></param>
        /// <param name="stopWords"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveStopWords(this IEnumerable<string> input, string[] stopWords)
        {
            return input.Except(stopWords);
        }
    }
}
