using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.truck.com.Models
{
    public class TruckModel
    {
        public IEnumerable<Truck.Core.Model.Truck> Trucks { get; set; }

        public string years { get; set; }

        public string weeks { get; set; }
    }
}