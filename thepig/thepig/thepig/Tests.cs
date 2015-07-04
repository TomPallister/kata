using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Moonpig
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void test_479838765467890()
        {
            var t = new PhoneNumberFormat();
            //Hard coded input for testing purpose. Take it from user.
            //Check for maximum input length of 100.
            var input = "479838765467890";
            var formatted = t.FormatTelephoneNumber(input);   
            Console.WriteLine(formatted);
        }

        [Test]
        public void test_messy()
        {
            var t = new PhoneNumberFormat();
            //Hard coded input for testing purpose. Take it from user.
            //Check for maximum input length of 100.
            var input = "4798*7654£$^&)38765467890";
            var formatted = t.FormatTelephoneNumber(input);
            Console.WriteLine(formatted);
        }

        [Test]
        public void test_small()
        {
            var t = new PhoneNumberFormat();
            //Hard coded input for testing purpose. Take it from user.
            //Check for maximum input length of 100.
            var input = "";
            var formatted = t.FormatTelephoneNumber(input);
            Console.WriteLine(formatted);
        }

        [Test]
        public void test_massive()
        {
            var t = new PhoneNumberFormat();
            //Hard coded input for testing purpose. Take it from user.
            //Check for maximum input length of 100.
            var input = "98765432345678987654321234567890987654321234567890987654323456783546789876545657898765435456789087654344567898765432678909876543235678909876543389876543456789098765432345678909876543234567890987654321234567899876543234567890987654323456776543236786543456738765467890";
            var formatted = t.FormatTelephoneNumber(input);
            Console.WriteLine(formatted);
        }

        [Test]
        public void square_test()
        {
            Square square = new Square();
            var result = square.solution(4, 17);
            Console.WriteLine(result);
        }
    }
}
