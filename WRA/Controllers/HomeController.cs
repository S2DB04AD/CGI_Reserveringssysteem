using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tempApp.Models;

namespace tempApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            DataAcces.Class1 class1 = new DataAcces.Class1();
            class1.ConnectDB();
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }


        public IActionResult ReportProblem()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
