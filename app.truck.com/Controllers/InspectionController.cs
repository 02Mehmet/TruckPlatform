using app.truck.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck.Core.Model;
using Truck.Data.Entities;

namespace app.truck.com.Controllers
{
    public class InspectionController : Controller
    {
        private InspectionRepository inspectionRepository = new InspectionRepository();

        private TruckUtility truckUtility = new TruckUtility();

        private static InspectionModel inspectionModel = new InspectionModel();

        private static string year = null;

        private static string week = null;

        private InspectionUtility inspectionUtility = new InspectionUtility();

        private CommonUtility commonUtility = new CommonUtility();

        // GET: Inspection
        public ActionResult Index()
        {
            ViewBag.YearList = commonUtility.Years();
            ViewBag.WeekList = commonUtility.Weeks();

            var data = inspectionRepository.GetAll();
            inspectionModel.Inspections = data;

            if (year != null && week != null)
            {
                var filterByYearAndWeek = inspectionUtility.
                    FilterByYearAndWeek(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                ViewBag.WeeklyAmount = filterByYearAndWeek.Sum(w => w.Amount);
                inspectionModel.Inspections = filterByYearAndWeek;
            }
            if (year != null && week == null)
            {
                var filterByYear = inspectionUtility.
                    FilterByYear(Convert.ToInt32(year)).Values;
                inspectionModel.Inspections = filterByYear;
            }
            if (year == null && week != null)
            {
                TempData["Message"] = "You can not send filter just only use week, please select year also";
                return RedirectToAction("Messages", "Inspection");
            }
            if (year == null && week == null)
            {
                year = Convert.ToString(DateTime.Now.Year);
                week = Convert.ToString(commonUtility.GetWeekNumber(DateTime.Now));
                var filterByYearAndWeek = inspectionUtility.
                    FilterDefault(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                ViewBag.WeeklyAmount = filterByYearAndWeek.Sum(w => w.Amount);
                inspectionModel.Inspections = filterByYearAndWeek;
            }

            return View(inspectionModel);
        }

        [HttpPost]
        public ActionResult Index(InspectionModel inspectionModel)
        {
            year = inspectionModel.years;
            week = inspectionModel.weeks;

            ViewBag.YearList = commonUtility.Years();
            ViewBag.WeekList = commonUtility.Weeks();

            var data = inspectionRepository.GetAll();

            if (year != null && week != null)
            {
                var filterByYearAndWeek = inspectionUtility.
                    FilterByYearAndWeek(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                ViewBag.WeeklyAmount = filterByYearAndWeek.Sum(w => w.Amount);
                inspectionModel.Inspections = filterByYearAndWeek;
            }
            if (year != null && week == null)
            {
                var filterByYear = inspectionUtility.
                    FilterByYear(Convert.ToInt32(year)).Values;
                inspectionModel.Inspections = filterByYear;
            }
            if (year == null && week != null)
            {
                //var filterByWeek = inspectionUtility.
                //    FilterByYear(Convert.ToInt32(week)).Values;
                //inspectionModel.Inspections = filterByWeek;
                TempData["Message"] = "You can not send filter just only use week, please select year also";
                return RedirectToAction("Messages", "Inspection");
            }
            if (year == null && week == null)
            {
                year = Convert.ToString(DateTime.Now.Year);
                week = Convert.ToString(commonUtility.GetWeekNumber(DateTime.Now));
                var filterByYearAndWeek = inspectionUtility.
                    FilterDefault(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                ViewBag.WeeklyAmount = filterByYearAndWeek.Sum(w => w.Amount);
                inspectionModel.Inspections = filterByYearAndWeek;
            }

            return View(inspectionModel);
        }

        public ActionResult Create()
        {
            ViewBag.PlateNumbers = truckUtility.GetPlateNumbers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inspection inspection)
        {
            inspection.Amount = 50;
            inspection.Week = commonUtility.
                GetWeekNumber(inspection.InspectionDate);
            var data = inspectionUtility.
                FilterByPlateNumber(inspection.InspectionDate.Year, inspection.Week, inspection.Truck.PlateNumber);
            if (data.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    inspectionRepository.Add(inspection);
                    return RedirectToAction("Index", "Inspection");
                }
            }
            else
            {
                TempData["Message"] = "Please try with another Plate , because this truck has already inspection for this week";
                return RedirectToAction("Messages", "Inspection");
            }

            return View(inspection);
        }


        public ActionResult Delete(int id = 0)
        {
            var data = inspectionRepository.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inspectionRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            var data = inspectionRepository.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        public ActionResult Messages()
        {
            return View();
        }
    }
}