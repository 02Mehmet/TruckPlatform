using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Truck.Data.Entities
{
    public class CommonUtility
    {
        public int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public List<SelectListItem> Years()
        {
            var list = new List<SelectListItem>();
            for (var i = 2000; i < 2050; i++)
                list.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

            return list;
        }

        public List<SelectListItem> Weeks()
        {
            var list = new List<SelectListItem>();
            for (var i = 1; i < 53; i++)
                list.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

            return list;
        }
    }
}
