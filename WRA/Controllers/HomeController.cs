﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using tempApp.Models;
using WRA.Models;
using System.Data;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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
                model.RoomNr = reservation.RoomNr;

                reservationModels.Add(model);
            }
            return View(reservationModels);
        }

        // Overzicht / index van de workplaces
        public IActionResult IndexWorkplace()
        {
            List<WorkplaceArea> resModel = QueryController.GetReservationsListWorkplace();
            List<WorkareaModel> reservationModels = new List<WorkareaModel>();
            foreach (WorkplaceArea reservation in resModel)
            {
                WorkareaModel model = new WorkareaModel();
                model.ID = reservation.ID;
                model.Accessories = reservation.Accessories;
                model.Used = reservation.Used;
                model.AmountPeople = reservation.AmountPeople;
                model.Number = reservation.Number;

                reservationModels.Add(model);
            }
            return View(reservationModels);
        }

        public IActionResult Login() {
            return View();
        }
        [Authorize]
        public IActionResult ReportProblem()
        {
            return View();
        }
        [Authorize]
        public IActionResult Reservation()
        {
            return View();
        }

        public IActionResult ReservationCreate()
        {
            return View();
        }

        public IActionResult ReservationWorkplace()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReservationCreate(ReservationModel reservation)
        {
            DAL.Reservation reservationModel = new DAL.Reservation();

            reservationModel.AmountPeople = reservation.AmountPeople;
            reservationModel.Used = reservation.Used;
            reservationModel.StartTime = reservation.StartTime;
            reservationModel.EndTime = reservation.EndTime;
            reservationModel.ResDate = reservation.ResDate;
            reservationModel.WorkplaceId = reservation.WorkplaceId;

            QueryController.CreateReservation(reservationModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ReservationWorkplace(WorkareaModel reservation)
        {
            DAL.WorkplaceArea workplaceArea = new DAL.WorkplaceArea();

            workplaceArea.AmountPeople = reservation.AmountPeople;
            workplaceArea.Used = reservation.Used;
            workplaceArea.Accessories = reservation.Accessories;
            workplaceArea.Number = reservation.Number;
            workplaceArea.Name = reservation.Name;

            QueryController.CreateReservationWorkplace(workplaceArea);
            return RedirectToAction(nameof(ReservationWorkplace));
        }
        
        [Authorize(Roles = "ADMIN,SECRETARY")]
        public IActionResult WallOfShame()
        {
            List<WallOfShame> wallOfShameModel = QueryController.GetUserNamesWallOfShame();
            List<WallOfShameModel> wallOfShameModels = new List<WallOfShameModel>();
            foreach (WallOfShame wallOfShame in wallOfShameModel) {
                WallOfShameModel wModel = new WallOfShameModel();
                wModel.UserId = wallOfShame.UserId;
                wModel.UserName = wallOfShame.UserName;

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

        public IActionResult WallOfShameDetails(int id)
        {
            List<WallOfShame> wallOfShameList = QueryController.GetWallOfShameList(id);

            var wallOfShame = wallOfShameList.Find(user => user.UserId == id);
            WallOfShameModel wallOfShameModel = new WallOfShameModel();
            wallOfShameModel.UserId = wallOfShame.UserId;
            wallOfShameModel.UserName = wallOfShame.UserName;
            wallOfShameModel.RoomNr = wallOfShame.RoomNr;
            wallOfShameModel.StartTime = wallOfShame.StartTime;
            wallOfShameModel.EndTime = wallOfShame.EndTime;
            wallOfShameModel.Date = wallOfShame.Date;
            wallOfShameModel.Used = wallOfShame.Used;
            return View(wallOfShameModel);
        }

        public IActionResult WallOfShameReservations(int id)
        {
            List<WallOfShame> wallOfShameList = QueryController.GetReservationsFromUserWallOfShame(id);

            var wallOfShame = wallOfShameList.Find(reservation => reservation.UserId == id);
            WallOfShameModel wallOfShameModel = new WallOfShameModel();
            wallOfShameModel.UserId = wallOfShame.UserId;
            wallOfShameModel.UserName = wallOfShame.UserName;
            wallOfShameModel.RoomNr = wallOfShame.RoomNr;
            wallOfShameModel.StartTime = wallOfShame.StartTime;
            wallOfShameModel.EndTime = wallOfShame.EndTime;
            wallOfShameModel.Date = wallOfShame.Date;
            wallOfShameModel.Used = wallOfShame.Used;
            return View(wallOfShameModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
