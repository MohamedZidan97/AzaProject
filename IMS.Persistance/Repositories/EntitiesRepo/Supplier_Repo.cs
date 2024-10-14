using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Domain.View_Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class Supplier_Repo : ISuppliersRepo
    {
        ApplicationDbContext dbcontext;

        public Supplier_Repo(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<Supplier_Details_ViewModel> GetAllSupplier(string user_id)
        {
            var list = from user_supplier in dbcontext.user_Suppliers
                       join supplier in dbcontext.suppliers on user_supplier.SupplierId equals supplier.SupplierId
                       where user_supplier.UserId == user_id
                       select new Supplier_Details_ViewModel
                       {
                           Supplier_Id = supplier.SupplierId,
                           Supplier_Name = supplier.SupplierName,
                           Supplier_Image = supplier.Image,
                           Supplier_ContactInfo = supplier.ContactInfo
                       };
            return list.ToList();
        }

        public void AddSupplier(Supplier supplier, string user_id)
        {
            dbcontext.suppliers.Add(supplier);
            dbcontext.SaveChanges();
            Supplier ssupplier = dbcontext.suppliers.FirstOrDefault(sp => sp.SupplierName == supplier.SupplierName && sp.ContactInfo == supplier.ContactInfo) ?? new Supplier();
            User_Supplier user_supplier = new User_Supplier();
            user_supplier.UserId = user_id;
            user_supplier.SupplierId = ssupplier.SupplierId;
            dbcontext.user_Suppliers.Add(user_supplier);
            dbcontext.SaveChanges();
        }

        public void DeleteSupplier(int supplier_id)
        {
            Supplier supplier = dbcontext.suppliers.SingleOrDefault(sp => sp.SupplierId == supplier_id) ?? new Supplier();
            dbcontext.suppliers.Remove(supplier);
            dbcontext.SaveChanges();
        }

        public Supplier GetSupplierById(int supplier_id)
        {
            Supplier supplier = dbcontext.suppliers.FirstOrDefault(sp => sp.SupplierId == supplier_id) ?? new Supplier();
            return supplier;
        }

        public void UpdateSupplier(int supplier_id, Supplier supplier)
        {
            Supplier oldsupplier = GetSupplierById(supplier_id);
            oldsupplier.SupplierName = supplier.SupplierName;
            oldsupplier.ContactInfo = supplier.ContactInfo;
            oldsupplier.Image = supplier.Image;
            dbcontext.SaveChanges();
        }

    }
}
