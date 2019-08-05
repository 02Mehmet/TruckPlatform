using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Truck.Data.Contracts
{
    public interface ITruckRepository
    {
        Task AddAsync(Truck.Core.Model.Truck truck);

        Task UpdateAsync(Truck.Core.Model.Truck truck);

        Task< IEnumerable<Truck.Core.Model.Truck>> GetAllAsync();

        Task< Truck.Core.Model.Truck> GetAsync(int id );

        Task DeleteAsync(int id);
    }
}
