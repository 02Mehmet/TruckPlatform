using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Business.Contracts;
using Truck.Core.Model;
using Truck.Data.Contracts;

namespace Truck.Business
{
    public class TruckBusiness : ITruckEngine
    {
        private readonly ITruckRepository _truckRepository;

        public TruckBusiness(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task Add(Core.Model.Truck truck)
        {
            await _truckRepository.AddAsync(truck);
        }

        public async Task Delete(int id)
        {
            await _truckRepository.DeleteAsync(id);
        }

        public async Task<Core.Model.Truck> Get(int id)
        {
            return await _truckRepository.GetAsync(id);
        }

        public Task<IEnumerable<Core.Model.Truck>> GetAll()
        {
            return _truckRepository.GetAllAsync();
        }

        public async Task Update(Core.Model.Truck truck)
        {
            await _truckRepository.UpdateAsync(truck);
        }
    }
}
