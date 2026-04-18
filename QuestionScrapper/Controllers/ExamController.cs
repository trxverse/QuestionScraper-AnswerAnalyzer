using Microsoft.AspNetCore.Mvc;

namespace QuestionScrapper.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
