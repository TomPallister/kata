using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzzKata
{
    [TestFixture]
    public class Tests
    {
        private FizzBuzzer _fizzBuzzer;

        [SetUp]
        public void set_up()
        {
            _fizzBuzzer = new FizzBuzzer();
        }

        [Test]
        public void number_divisible_by_three_is_replaced_by_the_word_fizz()
        {
            var input = 3;
            var result = _fizzBuzzer.Answer(input);
            result.Should().Be("fizz");
        }

        [Test]
        public void any_number_divisible_by_five_is_replaced_by_the_word_buzz()
        {
            var input = 5;
            var result = _fizzBuzzer.Answer(input);
            result.Should().Be("buzz");
        }

        [Test]
        public void any_number_divisible_by_five_and_three_is_replaced_by_the_word_fizzbuzz()
        {
            var input = 15;
            var result = _fizzBuzzer.Answer(input);
            result.Should().Be("fizzbuzz");
        }

        [Test]
        public void any_number_not_divisible_by_five_and_three_is_itself()
        {
            var input = 1;
            var result = _fizzBuzzer.Answer(input);
            result.Should().Be(input.ToString());
        }
    }
}
