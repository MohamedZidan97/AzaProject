﻿using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Application.Interfaces.IEntitiesRepo
{
    public interface IProduct2Repo
    {
        public List<Product_Details_ViewModel> GetAllProductOfCurrentUser(string user_id);
        public List<Product_Details_ViewModel> GetAllProductOfLowLevel(string user_id);
        public List<Product> GetAllProductForCustomer();
        public List<ProductShipped> GetAllShippedProductForCustomer(string customer_id);
        public bool AddToCart(Customer_Product customer_product);
        public void AddNewBuyingProccess(Buying_Proccess buying_process_model);
        public void DeleteProductFromShippingCart(string customer_id, int product_id);
    }
}
