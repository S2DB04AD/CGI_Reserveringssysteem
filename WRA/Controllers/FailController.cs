using Microsoft.AspNetCore.Mvc;

namespace WRA.Controllers
{
    public class FailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
