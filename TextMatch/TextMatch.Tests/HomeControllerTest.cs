using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using TextMatch.Controllers;

namespace TextMatch.Tests
{
    public class HomeControllerTest
    {
        [Test]
        public void can_get_home_happy_path()
        {
            var homeController = new HomeController();
            var indexPage = homeController.Index() as ViewResult;
            var title = (string) indexPage.ViewBag.Title;
            title.Should().Be("TextMatch Home Page");
        }
    }
}