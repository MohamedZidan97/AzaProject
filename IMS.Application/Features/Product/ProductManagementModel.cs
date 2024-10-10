using IMS.Domain.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Product
{
    public class ProductManagementModel
    {
        public class GeneralResponse
        {
            public bool Done { get; set; }
            public string Message { get; set; }
        }

        public class GetProductsResponse
        {
            public int ProductId { get; set; } = 0;
            public string ProductName { get; set; } = string.Empty;
            public decimal Price { get; set; } = 0;
            public string? ImageUrl { get; set; } = string.Empty;

        }

        public class GetProductByIdResponse
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public int LowStock { get; set; }
            public string? Photo { get; set; }
            public int SubCategoryId { get; set; }
            public int SupplierId { get; set; }

            public string? SubCategoryName { get; set; }
            public string? SupplierName { get; set; }


        }
        public class UpdateProductRequest
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; } = 0;
            public int Stock { get; set; } = 0;
            public int LowStock { get; set; } = 0;
            public IFormFile? Photo { get; set; }
            public int SubCategoryId { get; set; } = 0;
            public int SupplierId { get; set; } = 0;
            public string ApplicationUserId { get; set; }


        }
        public class AddProductRequest
        {
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public int LowStock { get; set; }
            public IFormFile? Photo { get; set; }
            public int SubCategoryId { get; set; }
            public int SupplierId { get; set; }
            public string? ApplicationUserId { get; set; }

        }
    }
}
