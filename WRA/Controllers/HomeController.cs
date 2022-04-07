using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using tempApp.Models;
using WRA.Models;
using System.Data;

namespace tempApp.Controllers
{
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }
        
        public IActionResult Index() {
            DB DBCon = new DB();
            List<Reservation> reservations = DBCon.GetReservations();
            List<ReservationModel> reservationModels = new List<ReservationModel>();
            foreach (Reservation reservation in reservations)
            {
                ReservationModel model = new ReservationModel();
                model.ResDate = reservation.ResDate;
                model.AmountPeople = reservation.AmountPeople;
                model.Used = reservation.Used;
                model.StartTime = reservation.StartTime;
                model.EndTime = reservation.EndTime;

                reservationModels.Add(model);
            }
            return View(reservationModels);
        }

        public IActionResult Login() {
            return View();
        }
        
        public IActionResult ReportProblem()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            //// Fields
            //DataTable reservationTable = new DataTable();
            //DateTime ResDate = DateTime.Now;
            //TimeSpan Time = TimeSpan.Zero;
            //string queryReservation;

            //// Method for query
            //void insertQuery(DateTime resdate, TimeSpan time)
            //{
            //    resdate = ResDate;
            //    time = Time;
            //    queryReservation = "INSERT INTO Reservation (ResDate, Used, AmountPeople, StartTime, EndTime, WorkplaceId) VALUES (" + resdate + ", 1, 2, " + time + ", " + time + ", 1)";
            //    reservationTable.Rows.Add(queryReservation);
            //    DAL.DbController.Create(queryReservation, reservationTable);
            //}
            return View();
        }

        public IActionResult WallOfShame()
        {
            List<WallOfShameModel> wallOfShameList = new List<WallOfShameModel>();
            WallOfShameModel wallOfShame = new WallOfShameModel();
            wallOfShame.Username = "Henk";
            wallOfShame.RoomNr = "Ruimte B1";
            wallOfShame.DateTime = DateTime.Now;
            wallOfShame.Used = true;
            WallOfShameModel wallOfShame2 = new WallOfShameModel();
            wallOfShame2.Username = "Sjaak";
            wallOfShame2.RoomNr = "Ruimte A3";
            wallOfShame2.DateTime = DateTime.Now;
            wallOfShame2.Used = false;
            WallOfShameModel wallOfShame3 = new WallOfShameModel();
            wallOfShame3.Username = "Anne Fleur Flair";
            wallOfShame3.RoomNr = "Ruimte R4";
            wallOfShame3.DateTime = DateTime.Now;
            wallOfShame3.Used = false;
            wallOfShameList.Add(wallOfShame);
            wallOfShameList.Add(wallOfShame2);
            wallOfShameList.Add(wallOfShame3);
            return View(wallOfShameList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
