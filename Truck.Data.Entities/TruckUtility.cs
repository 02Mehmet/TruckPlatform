using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Truck.Core.Context;

namespace Truck.Data.Entities
{
    public  class TruckUtility
    {
        private DBContext _dBContext = new DBContext();

        public Dictionary<int,Core.Model.Truck> FilterByYearAndWeek(int year, int week)
        {
            return _dBContext.Trucks.
                Where(a => a.ProcessTime.Year == year && a.Week == week).ToDictionary(x => x.TruckID, y => y);
        }

        public Dictionary<int,Core.Model.Truck> FilterByYear(int year)
        {
            return _dBContext.Trucks.
                Where(a => a.ProcessTime.Year == year).ToDictionary(x => x.TruckID, y => y);
        }

        public Dictionary<int,Core.Model.Truck> FilterByWeek(int week)
        {
            return _dBContext.Trucks.
                Where(a => a.Week == week).ToDictionary(x => x.TruckID, y => y);
        }

        public Dictionary<int,Truck.Core.Model.Truck> FilterDefault(int year, int week)
        {                      
            return _dBContext.Trucks.
                Where(a => a.ProcessTime.Year == year && a.Week == week).ToDictionary(x => x.TruckID, y => y);
        }

        public IEnumerable<SelectListItem> GetPlateNumbers()
        {
            IEnumerable<SelectListItem> items = _dBContext.Trucks.Where(a=>a.Status==true).OrderBy(a=>a.ProcessTime).Select(c => new SelectListItem
            {
                Value = c.PlateNumber,
                Text = c.PlateNumber

            });

            return items;
        }
    }
}
