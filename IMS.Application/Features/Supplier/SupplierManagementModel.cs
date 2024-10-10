using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Supplier
{
    public class SupplierManagementModel
    {
        public class GetSuppliersResponse
        {
            public int SupplierId { get; set; }
            public string SupplierName { get; set;}
        }
    }
}
