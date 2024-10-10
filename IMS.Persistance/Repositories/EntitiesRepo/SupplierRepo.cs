using IMS.Application.Interfaces;
using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Supplier.SupplierManagementModel;

namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly IBaseRepo<Supplier> baseRepo;

        public SupplierRepo(IBaseRepo<Supplier> baseRepo)
        {
            this.baseRepo = baseRepo;
        }


        public async Task<IEnumerable<GetSuppliersResponse>> GetSuppliersRepo()
        {
            var sups= await baseRepo.GetAllAsync();

            return sups.Select(e => new GetSuppliersResponse
            {
                SupplierId = e.SupplierId,
                SupplierName = e.SupplierName
            }).ToList();

        }
    }
}
