using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class FizzBuzzer
    {
        public string Answer(int input)
        {
            if (input % 5 == 0 && input % 3 == 0)
            {
                return "fizzbuzz";
            }
            if (input%5 == 0)
            {
                return "buzz";
            }
            if (input%3 == 0)
            {
                return "fizz";
            }
            return input.ToString();
        }
    }
}
