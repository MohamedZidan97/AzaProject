using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Domain.View_Model;
using Microsoft.AspNetCore.Identity;
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
                           Supplier_First_Name = supplier.SupplierFirstName,
                           Supplier_Last_Name = supplier.SupplierLastName,
                           Supplier_UserName = supplier.UserName,
                           Supplier_Email = supplier.Email,
                           Supplier_Image = supplier.Image,
                           Supplier_PhoneNumber = supplier.PhoneNumber
                       };
            return list.ToList();
        }

        public void AddSupplier(Supplier supplier, string user_id)
        {
            dbcontext.suppliers.Add(supplier);
            dbcontext.SaveChanges();
            Supplier ssupplier = dbcontext.suppliers.FirstOrDefault(sp => sp.SupplierFirstName == supplier.SupplierFirstName && sp.PhoneNumber == supplier.PhoneNumber) ?? new Supplier();
            User_Supplier user_supplier = new User_Supplier();
            user_supplier.UserId = user_id;
            user_supplier.SupplierId = ssupplier.SupplierId;
            dbcontext.user_Suppliers.Add(user_supplier);
            dbcontext.SaveChanges();
        }

        public void DeleteSupplier(int supplier_id,ApplicationUser applicationuser)
        {
            Supplier supplier = dbcontext.suppliers.SingleOrDefault(sp => sp.SupplierId == supplier_id) ?? new Supplier();
            dbcontext.suppliers.Remove(supplier);
            dbcontext.ApplicationUsers.Remove(applicationuser);
            dbcontext.SaveChanges();
        }

        public Supplier GetSupplierById(int supplier_id)
        {
            Supplier supplier = dbcontext.suppliers.FirstOrDefault(sp => sp.SupplierId == supplier_id) ?? new Supplier();
            return supplier;
        }

        public void UpdateSupplier(int supplier_id, Supplier supplier,ApplicationUser applicationuser)
        {
            Supplier oldsupplier = GetSupplierById(supplier_id);
            oldsupplier.SupplierFirstName  = applicationuser.FirstName = supplier.SupplierFirstName;
            oldsupplier.SupplierLastName   = applicationuser.LastName = supplier.SupplierLastName;
            oldsupplier.UserName  = applicationuser.UserName = supplier.UserName;
            oldsupplier.Email  = applicationuser.Email = supplier.Email;
            oldsupplier.PhoneNumber  = applicationuser.PhoneNumber = supplier.PhoneNumber;
            oldsupplier.Image = supplier.Image;
            dbcontext.SaveChanges();
        }


        public ApplicationUser GetMatchedSupplierInApplicationUser(string user_name)
        {
            ApplicationUser applicationuser = dbcontext.ApplicationUsers.SingleOrDefault(app => app.UserName == user_name) ?? new ApplicationUser();
            return applicationuser;
        }
    }
}
