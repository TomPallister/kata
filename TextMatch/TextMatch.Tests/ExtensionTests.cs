using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TextMatch.Extension;

namespace TextMatch.Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void can_convert_list_int_to_comma_delimited_string()
        {
            var ints = new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            };

            ints.ConvertToCommaDelimitedString().Should().Be("1,2,3,4,5");
        }

        [Test]
        public void can_handle_empty_list()
        {
            var ints = new List<int>();
            ints.ConvertToCommaDelimitedString().Should().Be("");
        }

        [Test]
        public void can_convert_string_to_char_array()
        {
            const string input = "mr chips";
            var array = input.ConvertToCharArray();
            array.Length.Should().Be(8);
        }

        [Test]
        public void can_handle_empty_string()
        {
            const string input = "";
            var array = input.ConvertToCharArray();
            array.Length.Should().Be(0);
        }
    }
}
