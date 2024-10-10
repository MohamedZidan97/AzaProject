using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Supplier.SupplierManagementModel;

namespace IMS.Application.Interfaces.IEntitiesRepo
{
    public interface ISupplierRepo
    {
        Task<IEnumerable<GetSuppliersResponse>> GetSuppliersRepo();
    }
}
