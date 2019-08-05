using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Core.Model
{
    public class Truck
    {
        public Truck()

        {
            Inspections = new HashSet<Inspection>();
        }
        [Key]
        public int TruckID { get; set; }

        public ICollection<Inspection> Inspections { get; set; }

        public string PlateNumber { get; set; }

        public bool Status { get; set; }

        public DateTime ProcessTime { get; set; }

        public int Week { get; set; }

    }
}
