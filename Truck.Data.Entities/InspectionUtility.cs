using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Truck.Core.Context;
using Truck.Core.Model;

namespace Truck.Data.Entities
{
    public class InspectionUtility
    {
        private DBContext _dBContext = new DBContext();

        public IEnumerable<Inspection> FilterByYearAndWeek(int year, int week)
        {
            return _dBContext.Inspections.
                Where(a => a.InspectionDate.Year == year && a.Week == week);
        }

        //public Dictionary<int, Inspection> FilterByYearAndWeek(int year, int week)
        //{
        //    return _dBContext.Inspections.Where(a => a.InspectionDate.Year == year && a.Week == week).ToDictionary(x => x.InspectionID, y => y);
        //}

        public IEnumerable<Inspection> FilterByYear(int year)
        {
            return _dBContext.Inspections.
                Where(a => a.InspectionDate.Year == year);
        }

        public IEnumerable<Inspection> FilterByWeek(int week)
        {
            return _dBContext.Inspections.
                Where(a => a.Week == week);
        }

        public IEnumerable<Inspection> FilterDefault(int year, int week)
        {
            return _dBContext.Inspections.
                Where(a => a.InspectionDate.Year == year && a.Week == week);
        }

        public IEnumerable<Inspection> FilterByPlateNumber(int year, int week, string plateNumber)
        {
            return _dBContext.Inspections.
                Where(a => a.InspectionDate.Year == year && a.Week == week && a.Truck.PlateNumber == plateNumber);
        }
    }
}
