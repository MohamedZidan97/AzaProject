using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class Product_Repo : IProduct2Repo
    {
        ApplicationDbContext dbcontext;
        public Product_Repo(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Product_Details_ViewModel> GetAllProductOfCurrentUser(string user_id)
        {

            var list = from user_supplier in dbcontext.user_Suppliers
                       join supplier in dbcontext.suppliers on user_supplier.SupplierId equals supplier.SupplierId
                       join product in dbcontext.products on supplier.SupplierId equals product.SupplierId
                       where user_supplier.UserId == user_id
                       select new Product_Details_ViewModel
                       {
                           Supplier_Name = supplier.SupplierFirstName + " " + supplier.SupplierLastName,
                           Product_Image = product.Image,
                           Product_Name = product.ProductName,
                           Product_Stock = product.Stock,
                           Product_Low_Stock = product.LowStock
                       };
            return list.ToList();
        }
    }
}
