using FluentAssertions;
using NUnit.Framework;
using TextMatch.Service;

namespace TextMatch.Tests
{
    public class TextMatchServiceTests
    {
        private string _testText;
        private ITextMatchService _textMatchService;

        [SetUp]
        public void set_up()
        {
            _textMatchService = new TextMatchService();
            _testText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
        }

        [Test]
        public void polly_returns_1_26_51()
        {
            const string subtext = "Polly";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("1,26,51");
        }

        [Test]
        public void ll_bracket_ell_ell_bracket_returns_3_28_53_78_82()
        {
            const string subtext = "ll (ell ell)";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("3,28,53,78,82");
        }

        [Test]
        public void text_11112_with_12_subtext_returns_4()
        {
            const string subtext = "12";
            _testText = "11112";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("4");
        }

        [Test]
        public void x_returns_there_is_no_output()
        {
            const string subtext = "X";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("There is no output");
        }

        [Test]
        public void empty_string_text_returns_there_is_no_output()
        {
            const string subtext = "X";
            _testText = "";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("There is no output");
        }

        [Test]
        public void empty_string_subtext_returns_there_is_no_output()
        {
            const string subtext = "";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("There is no output");
        }

        [Test]
        public void empty_string_subtext_and_text_returns_there_is_no_output()
        {
            const string subtext = "";
            _testText = "";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("There is no output");
        }

        [Test]
        public void polx_returns_there_is_no_output()
        {
            const string subtext = "Polx";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("There is no output");
        }

        [Test]
        public void aa_in_aaa_returns_one_two_three()
        {
            const string subtext = "aa";
            _testText = "aaaa";
            var result = _textMatchService.ProcessInputs(_testText, subtext);
            result.Should().Be("1,2,3");
        } 
    }
}