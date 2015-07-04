using System;
using System.Text;

namespace Moonpig
{
    public class PhoneNumberFormat
    {
        public string FormatTelephoneNumber(string S)
        {
            //set up a string builder that we will use collet valid characters
            var stringBuilder = new StringBuilder();
            //set a counter to make sure we get valid characters
            var count = 0;
            //check each character
            foreach (var character in S)
            {
                //is the character a number?
                if ("0123456789".IndexOf(character) == -1)
                {
                    //no then continue through the loop
                    continue;
                }
                //it is, increment count
                count++;
                //and add to string builder
                stringBuilder.Append(character);
            }
            //if the input contains less than 2 digits, return null
            if (count < 2)
            {
                return "";
            }
            //set up a new string builder containing only the numbers
            stringBuilder = new StringBuilder(stringBuilder.ToString());
            //we need to insert a dash after every 3rd character
            var insertDash = 3;
            while (insertDash < stringBuilder.Length)
            {
                //insert dashes
                stringBuilder.Insert(insertDash, "-");
                //wasnt sure how to do this bit but if we only have four characters we need to enter the dash after 2 characters
                if (insertDash == (stringBuilder.Length - 5))
                {
                    insertDash = insertDash + 3;
                }
                else
                {
                    insertDash = insertDash + 4;
                }
            }
            //return the formatted phone number
            return stringBuilder.ToString();
        }

    }
}