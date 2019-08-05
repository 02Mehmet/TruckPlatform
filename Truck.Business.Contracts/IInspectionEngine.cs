using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Model;

namespace Truck.Business.Contracts
{
    public interface IInspectionEngine
    {
        Task Add(Inspection truck);
        Task Update(Inspection truck);
        Task<IEnumerable<Inspection>> GetAll();
        Task<Inspection> Get(int id);
        Task Delete(int id);
    }
}
