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
                       join application_user in dbcontext.ApplicationUsers on customer_product.CustomerId equals application_user.Id
                       join supplier in dbcontext.suppliers on product.SupplierId equals supplier.SupplierId
                       where customer_product.CustomerId == customer_id
                       select new ProductShipped
                       {
                           Product_Id = product.ProductId,
                           Product_Image = product.Image,
                           Product_Name = product.ProductName,
                           Product_Price = product.Price,
                           Supplier_Id = supplier.SupplierId,
                           Supplier_Name = supplier.SupplierFirstName + " " + supplier.SupplierLastName,
                           Supplier_Email = supplier.Email,
                           Supplier_Phone = supplier.PhoneNumber,
                           Customer_Name = application_user.FirstName + " " + application_user.LastName,
                       };
            return list.ToList();
        }

        public bool AddToCart(Customer_Product customer_product)
        {
            var check_customer_product = dbcontext.customer_Products.FirstOrDefault
                (  bp => bp.CustomerId == customer_product.CustomerId
                && bp.ProductId == customer_product.ProductId
                );
            if (check_customer_product == null)
            {
                dbcontext.customer_Products.Add(customer_product);
                dbcontext.SaveChanges();
                return true ;
            }
            else
                return false;
        }

        public void AddNewBuyingProccess(Buying_Proccess buying_process_model)
        {
            dbcontext.Buying_Proccess.Add(buying_process_model);
            dbcontext.SaveChanges();
        }

        public void DeleteProductFromShippingCart(string customer_id , int product_id)
        {
            Customer_Product customer_Product = dbcontext.customer_Products.SingleOrDefault(cp => cp.CustomerId == customer_id && cp.ProductId == product_id);
            dbcontext.customer_Products.Remove(customer_Product);
            dbcontext.SaveChanges();
        }

    }
}
