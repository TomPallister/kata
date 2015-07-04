using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TextMatch.Extension
{
    public static class EnumberIntExtensions
    {

        /// <summary>
        /// This method converts a list of integers into a comma deliminated list
        /// </summary>
        /// <param name="matches">List of integers to deliminate</param>
        /// <returns></returns>
        public static string ConvertToCommaDelimitedString(this IEnumerable<int> matches)
        {
            var enumerable = matches as int[] ?? matches.ToArray();
            if (enumerable.Any())
            {
                //set up a string builder to build the string
                var stringBuilder = new StringBuilder();
                //loop through the matches if any
                foreach (int match in enumerable)
                {
                    //append the match to the string
                    stringBuilder.Append(match);
                    //append the comma
                    stringBuilder.Append(",");
                }
                //remove the last position in this string because it will be a , which is wrong.
                stringBuilder.Length = stringBuilder.Length - 1;
                //return the string
                return stringBuilder.ToString();
            }

            return "";
        }
    }
}