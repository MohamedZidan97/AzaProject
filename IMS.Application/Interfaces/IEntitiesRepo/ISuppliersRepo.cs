using IMS.Domain.Entites;
using IMS.Domain.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Application.Interfaces.IEntitiesRepo
{
    public interface ISuppliersRepo
    {
        public List<Supplier_Details_ViewModel> GetAllSupplier(string user_id);
        public void AddSupplier(Supplier supplier, string user_id);
        public void DeleteSupplier(int supplier_id, ApplicationUser applicationuser);
        public Supplier GetSupplierById(int supplier_id);
        public void UpdateSupplier(int supplier_id, Supplier supplier,ApplicationUser applicationuser);
        public ApplicationUser GetMatchedSupplierInApplicationUser(string user_name);


    }

}
