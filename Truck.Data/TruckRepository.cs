using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Model;
using Truck.Data.Contracts;

namespace Truck.Data
{
    public class TruckRepository : ITruckRepository
    {
        private Truck.Core.Context.DBContext _dBContext = new Core.Context.DBContext();
        public async Task AddAsync(Core.Model.Truck truck)
        {
            _dBContext.Trucks.Add(truck);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            Delete(item);
        }
        private void Delete(Core.Model.Truck entity)
        {
            _dBContext.Entry(entity).State = EntityState.Deleted;
            _dBContext.SaveChanges();
        }

        public async Task<Core.Model.Truck> GetAsync(int id)
        {
            return await _dBContext.Trucks.Where(x => x.TruckID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Core.Model.Truck>> GetAllAsync()
        {
            return await _dBContext.Trucks.ToListAsync();
        }

        public async Task UpdateAsync(Core.Model.Truck truck)
        {
            _dBContext.Entry(truck).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
