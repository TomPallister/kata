using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using TextMatch.Controllers;
using TextMatch.Models;
using TextMatch.Service;

namespace TextMatch.Tests
{
    public class MatchesControllerTest
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
        [HttpGet]
        public void can_get_index_happy_path()
        {
            var homeController = new MatchesController(_textMatchService);
            var textMatchInputModel = new TextMatchInputModel
            {
                SubText = "Polly",
                Text = _testText
            };
            var indexPage = homeController.Index(textMatchInputModel.Text, textMatchInputModel.SubText) as ViewResult;
            var model = (TextMatchOutputModel) indexPage.Model;
            model.Output.Should().Be("1,26,51");
        }
    }
}