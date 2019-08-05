using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Context;

namespace TestDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext dBContext = new DBContext();
            var data = dBContext.Trucks.ToList();
        }
    }
}
