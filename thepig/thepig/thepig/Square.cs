using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonpig
{
    using System;
    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can use Console.WriteLine for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    public class Square
    {
        public int solution(int A, int B)
        {
            var countOfSquare = 0;
            for (int i = A; i < B; i++)
            {
                var result = Math.Sqrt(i);
                var isSquare = Math.Abs(result%1) < double.Epsilon;
                if (isSquare)
                {
                    countOfSquare++;
                }
            }
            return countOfSquare;
        }
    }
}
