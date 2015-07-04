using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextMatch.Extension
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts a string to a char array
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns></returns>
        public static char[] ConvertToCharArray(this string input)
        {
            //create the array
            var array = new char[input.Length];
            //loop through the string adding chars to the array
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = input[i];
            }
            //return the array
            return array;
        }
    }
}