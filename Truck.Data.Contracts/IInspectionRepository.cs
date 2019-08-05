using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Data.Contracts
{
    public interface IInspectionRepository
    {
        Task AddAsync(Truck.Core.Model.Inspection inspection);

        Task UpdateAsync(Truck.Core.Model.Inspection inspection);

        Task<IEnumerable<Truck.Core.Model.Inspection>> GetAllAsync();

        Task<Truck.Core.Model.Inspection> GetAsync(int id);

        Task DeleteAsync(int id);
    }
}
