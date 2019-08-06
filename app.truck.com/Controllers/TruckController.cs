using app.truck.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck.Data.Entities;

namespace app.truck.com.Controllers
{
    public class TruckController : Controller
    {
        private TruckRepository truckRepository = new TruckRepository();

        private TruckUtility utility = new TruckUtility();

        private CommonUtility commonUtility = new CommonUtility();

        private static TruckModel truckModel = new TruckModel();

        private static string year = null;

        private static string week = null;

        public ActionResult Index()
        {
            ViewBag.YearList = commonUtility.Years();
            ViewBag.WeekList = commonUtility.Weeks();

            var data = truckRepository.GetAll();
            truckModel.Trucks = data;
    
            if (year != null && week != null)
            {
                var filterByYearAndWeek = utility.FilterByYearAndWeek(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByYearAndWeek;
            }
            if (year != null && week == null)
            {
                var filterByYear = utility.FilterByYear(Convert.ToInt32(year)).Values;
                truckModel.Trucks = filterByYear;
            }
            if (year == null && week != null)
            {
                var filterByWeek = utility.FilterByYear(Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByWeek;
            }
            if (year == null && week == null)
            {
                year = Convert.ToString(DateTime.Now.Year);
                week = Convert.ToString(commonUtility.GetWeekNumber(DateTime.Now));
                var filterByDefault = utility.FilterDefault(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByDefault;
            }
            return View(truckModel);

        }

        [HttpPost]
        public ActionResult Index(app.truck.com.Models.TruckModel truckModel)
        {
            year = truckModel.years;
            week = truckModel.weeks;

            ViewBag.YearList = commonUtility.Years();
            ViewBag.WeekList = commonUtility.Weeks();

            var data = truckRepository.GetAll();

            if (year != null && week != null)
            {
                var filterByYearAndWeek = utility.FilterByYearAndWeek(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByYearAndWeek;
            }
            if (year != null && week == null)
            {
                var filterByYear = utility.FilterByYear(Convert.ToInt32(year)).Values;
                truckModel.Trucks = filterByYear;
            }
            if (year == null && week != null)
            {
                var filterByWeek = utility.FilterByYear(Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByWeek;
            }
            if (year == null && week == null)
            {
                year = Convert.ToString(DateTime.Now.Year);
                week = Convert.ToString(commonUtility.GetWeekNumber(DateTime.Now));
                var filterByYearAndWeek = utility.FilterDefault(Convert.ToInt32(year), Convert.ToInt32(week)).Values;
                truckModel.Trucks = filterByYearAndWeek;
            }

            return View(truckModel);
        }


        public ActionResult Details(int id = 0)
        {
            var data = truckRepository.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Truck.Core.Model.Truck truck)
        {
            if (ModelState.IsValid)
            {
                truckRepository.Add(truck);
                return RedirectToAction("Index", "Truck");
            }

            return View(truck);
        }

        public ActionResult Delete(int id = 0)
        {
            var data = truckRepository.Get(id);
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
            truckRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddNewTruck()
        {
            return View();
        }

        public JsonResult TrucksAdd(Truck.Core.Model.Truck truck)
        {
            truck.Week = commonUtility.GetWeekNumber(truck.ProcessTime);
            if (truck != null)
            {
                truckRepository.Add(truck);
            }
            var result = "Success";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTruckByID(int id)
        {
            var data = truckRepository.Get(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}