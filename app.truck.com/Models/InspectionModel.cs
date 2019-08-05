using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Truck.Core.Model;

namespace app.truck.com.Models
{
    public class InspectionModel
    {
        public IEnumerable<Inspection> Inspections { get; set; }

        public string years { get; set; }

        public string weeks { get; set; }
    }
}