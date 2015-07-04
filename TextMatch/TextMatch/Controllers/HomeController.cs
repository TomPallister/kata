using System.Web.Mvc;
using TextMatch.Models;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "TextMatch Home Page";
            return View();
        }

        [HttpPost]
        public ActionResult Index(TextMatchInputModel textMatchInputModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Matches", new { text = textMatchInputModel.Text, subText = textMatchInputModel.SubText });
            }
            return View(textMatchInputModel);
        }
    }
}