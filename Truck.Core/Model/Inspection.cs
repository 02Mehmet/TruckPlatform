using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Core.Model
{
    public class Inspection
    {

        [Key]
        public int InspectionID { get; set; }
 
        public DateTime InspectionDate { get; set; }

        public string Note { get; set; }

        public double Amount { get; set; }

        public virtual Truck Truck { get; set; }

        public int Week { get; set; }

    }
}
