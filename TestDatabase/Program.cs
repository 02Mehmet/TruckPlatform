using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Context;
using Truck.Data.Entities;

namespace TestDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext dBContext = new DBContext();
            InspectionUtility inspectionUtility = new InspectionUtility();
            var data = inspectionUtility.
                FilterByPlateNumber(DateTime.Now.Year, 33, "12CB45");
        }
    }
}
