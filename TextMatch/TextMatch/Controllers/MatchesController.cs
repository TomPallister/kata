using System.Web.Mvc;
using TextMatch.Models;
using TextMatch.Service;

namespace TextMatch.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ITextMatchService _textMatchService;

        public MatchesController(ITextMatchService textMatchService)
        {
            _textMatchService = new TextMatchService();
        }

        /// <summary>
        ///     This route will match the text and subtext passed to it
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string text = "", string subText = "")
        {
            if (ModelState.IsValid)
            {
                //find any matches
                string matches = _textMatchService.ProcessInputs(text, subText);
                //set up the model
                var textMatchOutputModel = new TextMatchOutputModel(matches);
                //return the view
                return View(textMatchOutputModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}