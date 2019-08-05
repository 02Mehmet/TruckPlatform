using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Truck.Business.Contracts;
using Truck.Data.Entities;

namespace app.truck.com.Controllers
{
    public class HomeController : Controller
    {



        TruckRepository truckRepository = new TruckRepository();
        public ActionResult Index()
        {

            var data = truckRepository.GetAll();
            return View();
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}