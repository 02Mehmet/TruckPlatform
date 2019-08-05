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
    public class InspectionBusiness : IInspectionEngine
    {
        private readonly IInspectionRepository _inspectionRepository;

        public InspectionBusiness(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task Add(Inspection inspection)
        {
             await _inspectionRepository.AddAsync(inspection);
        }

        public async Task Delete(int id)
        {
            await _inspectionRepository.DeleteAsync(id);
        }

        public async Task<Inspection> Get(int id)
        {
            return await _inspectionRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Inspection>> GetAll()
        {
            return await _inspectionRepository.GetAllAsync();
        }

        public async Task Update(Inspection inspection)
        {
            await _inspectionRepository.UpdateAsync(inspection);
        }
    }
}
