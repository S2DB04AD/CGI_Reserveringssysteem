using Mailer;
using Microsoft.AspNetCore.Mvc;

namespace WRA.Controllers
{
    public class ProblemReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WRA.Models.ProblemModel problemModel)
        {
            const string FROM = "";
            const string TO = "";
            const string SUBJECT = "";
            string Message = string.Format("Room: {0}\nProblem: {1}\n", problemModel.Space, problemModel.Problem);

            MailServer.Send(FROM, TO, SUBJECT, Message);
            return View(problemModel);
        }
    }
}
