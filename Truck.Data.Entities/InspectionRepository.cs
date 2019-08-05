using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Context;
using Truck.Core.Model;

namespace Truck.Data.Entities
{
    public class InspectionRepository
    {
        private DBContext _dBContext = new DBContext();

        public void Add(Inspection inspection)
        {
            _dBContext.Inspections.Add(inspection);
            _dBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Get(id);
            Delete(item);
        }

        private void Delete(Inspection entity)
        {
            _dBContext.Entry(entity).State = EntityState.Deleted;
            _dBContext.SaveChanges();
        }

        public Inspection Get(int id)
        {
            return _dBContext.Inspections.Where(x => x.InspectionID == id).FirstOrDefault();
        }

        public IEnumerable<Inspection> GetAll()
        {
            return _dBContext.Inspections.ToList();
        }

        public void Update(Inspection inspection)
        {
            _dBContext.Entry(inspection).State = EntityState.Modified;
            _dBContext.SaveChanges();
        }
    }
}
