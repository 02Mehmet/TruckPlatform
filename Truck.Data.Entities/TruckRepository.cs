using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Data.Entities
{
    public class TruckRepository
    {
        private Truck.Core.Context.DBContext _dBContext = new Core.Context.DBContext();

        public void Add(Core.Model.Truck truck)
        {
            _dBContext.Trucks.Add(truck);
            _dBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item =  Get(id);
            Delete(item);
        }

        private void Delete(Core.Model.Truck entity)
        {
            _dBContext.Entry(entity).State = EntityState.Deleted;
            _dBContext.SaveChanges();
        }

        public Core.Model.Truck Get(int id)
        {
            return  _dBContext.Trucks.Where(x => x.TruckID == id).FirstOrDefault();
        }

        public IEnumerable<Core.Model.Truck> GetAll()
        {
            return  _dBContext.Trucks.ToList();
        }

        public void Update(Core.Model.Truck truck)
        {
            _dBContext.Entry(truck).State = EntityState.Modified;
            _dBContext.SaveChanges();
        }
    }
}
