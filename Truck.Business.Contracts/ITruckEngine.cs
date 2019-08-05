using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Business.Contracts
{
   public interface ITruckEngine
    {
        Task Add(Truck.Core.Model.Truck truck);
        Task Update(Truck.Core.Model.Truck truck);
        Task<IEnumerable<Truck.Core.Model.Truck>> GetAll();
        Task<Truck.Core.Model.Truck> Get(int id);
        Task Delete(int id);
    }
}
