using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<Product_Details_ViewModel> GetAllProductOfLowLevel(string user_id)
        {
            var list = from user_supplier in dbcontext.user_Suppliers
                       join supplier in dbcontext.suppliers on user_supplier.SupplierId equals supplier.SupplierId
                       join product in dbcontext.products on supplier.SupplierId equals product.SupplierId
                       where user_supplier.UserId == user_id && product.Stock <= product.LowStock
                       select new Product_Details_ViewModel
                       {
                           Supplier_Id = supplier.SupplierId,
                           Supplier_UserName = supplier.UserName,
                           Supplier_Name = supplier.SupplierFirstName + " " + supplier.SupplierLastName,
                           Product_Image = product.Image,
                           Product_Name = product.ProductName,
                           Product_Stock = product.Stock,
                           Product_Low_Stock = product.LowStock
                       };
            return list.ToList();
        }

        public List<Product> GetAllProductForCustomer()
        {
            List<Product> ListOfAllProducts = dbcontext.products.AsNoTracking().ToList();
            return ListOfAllProducts;
        }

        public List<ProductShipped> GetAllShippedProductForCustomer(string customer_id)
        {
            var list = from customer_product in dbcontext.customer_Products
                       join product in dbcontext.products on customer_product.ProductId equals product.ProductId
                       join supplier in dbcontext.suppliers on product.SupplierId equals supplier.SupplierId
                       where customer_product.CustomerId == customer_id
                       select new ProductShipped
                       {
                           Product_Image = product.Image,
                           Product_Name = product.ProductName,
                           Product_Price = product.Price,
                           Supplier_Name = supplier.SupplierFirstName + " " + supplier.SupplierLastName,
                           Supplier_Email = supplier.Email,
                           Supplier_Phone = supplier.PhoneNumber
                       };
            return list.ToList();
        }

        public void AddToCart(Customer_Product customer_product)
        {
            dbcontext.customer_Products.Add(customer_product);
            dbcontext.SaveChanges();
        }
    }
}
