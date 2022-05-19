using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using tempApp.Models;
using WRA.Models;
using System.Data;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace tempApp.Controllers {
    public class HomeController : Controller {

        public HomeController() {
        }

        [Authorize]
        public IActionResult Index() {
            List<Reservation> resModel = QueryController.GetReservationsList();
            List<ReservationModel> reservationModels = new List<ReservationModel>();
            foreach (Reservation reservation in resModel) {
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

        [Authorize]
        public IActionResult ReportProblem() {
            return View();
        }

        [Authorize]
        public IActionResult Reservation() {
            return View();
        }

        [Authorize(Roles = "ADMIN,SECRETARY")]
        public IActionResult WallOfShame() {
            List<WallOfShame> wallOfShameModel = QueryController.GetWallOfShameList();
            List<WallOfShameModel> wallOfShameModels = new List<WallOfShameModel>();
            foreach (WallOfShame wallOfShame in wallOfShameModel) {
                WallOfShameModel wModel = new WallOfShameModel();
                wModel.UserName = wallOfShame.UserName;
                wModel.RoomNr = wallOfShame.RoomNr;
                wModel.Date = wallOfShame.Date;
                wModel.StartTime = wallOfShame.StartTime;
                wModel.EndTime = wallOfShame.EndTime;

                wallOfShameModels.Add(wModel);
            }
            return View(wallOfShameModels);
            /*List<WallOfShameModel> wallOfShameList = new List<WallOfShameModel>();
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
            wallOfShameList.Add(wallOfShame3);*/
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
