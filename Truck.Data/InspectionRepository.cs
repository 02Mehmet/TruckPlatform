using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Context;
using Truck.Data.Contracts;
using Truck.Core.Model;
using System.Data.Entity;

namespace Truck.Data
{

    public class InspectionRepository : IInspectionRepository
    {
        private Truck.Core.Context.DBContext _dBContext = new Core.Context.DBContext();

        public async Task AddAsync(Inspection inspection)
        {
            _dBContext.Inspections.Add(inspection);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            Delete(item);
        }

        private void Delete(Inspection entity)
        {
            _dBContext.Entry(entity).State = EntityState.Deleted;
            _dBContext.SaveChanges();
        }

        public async Task<IEnumerable<Inspection>> GetAllAsync()
        {
            return await _dBContext.Inspections.ToListAsync();
        }

        public async Task<Inspection> GetAsync(int id)
        {
            return await _dBContext.Inspections.Where(x => x.InspectionID == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Inspection inspection)
        {
            _dBContext.Entry(inspection).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
