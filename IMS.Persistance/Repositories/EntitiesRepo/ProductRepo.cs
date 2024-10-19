using AutoMapper;
using IMS.Application.Interfaces;
using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IBaseRepo<Product> baseRepo;

        public ProductRepo(ApplicationDbContext dbContext, IMapper mapper,IBaseRepo<Product> baseRepo)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.baseRepo = baseRepo;
        }
        public async Task<IQueryable<GetProductsResponse>> GetAllProductsAsync(string UserId)
        {
            var products =  dbContext.products
                .Where(e=>e.ApplicationUserId == UserId)
                .Select(r=> new GetProductsResponse { ImageUrl = r.Image, ProductId =r.ProductId, Price = r.Price, ProductName = r.ProductName });
            return products;
        }

     
        public async Task<GeneralResponse> AddProductAsync(AddProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            product.Image = UploadImages.SaveFile(request.Photo, "Images");
           return await baseRepo.AddAsync(product);
        }



        public async Task<GetProductByIdResponse> GetProductByIdAsync(int ProductId)
        {
            var product = await dbContext.products.Where(e => e.ProductId == ProductId)
                .Select(r => new GetProductByIdResponse
                {
                    ProductId = r.ProductId,
                    LowStock = r.LowStock,
                    Photo = r.Image,
                    Price = r.Price,
                    ProductName = r.ProductName,
                    Stock = r.Stock,
                    SubCategoryId = r.SubCategoryId,
                    SupplierId = r.SupplierId,
                    SubCategoryName = r.SubCategory.Name,
                    SupplierName = r.Supplier.SupplierFirstName + r.Supplier.SupplierLastName
                }).FirstOrDefaultAsync();

            return product;
        }

        public async Task<GeneralResponse> UpdateProductAsync(UpdateProductRequest model)
        {
            var url = (await GetProductByIdAsync(model.ProductId)).Photo;
           
            string fileName = null;
            if (model.Photo != null)
            {
                fileName = UploadImages.SaveFile(model.Photo, "Images");
            }

            // Update product in repository
            var updatedProduct = new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Price = model.Price,
                Stock = model.Stock,
                LowStock = model.LowStock,
                SubCategoryId = model.SubCategoryId,
                SupplierId = model.SupplierId,
                Image = fileName??url,
                ApplicationUserId = model.ApplicationUserId
                 
                // Assuming your `Product` model has a PhotoPath field
            };

           return  await baseRepo.UpdateAsync(updatedProduct);

        }

        public async Task<GeneralResponse> DeleteProductAsync(int ProductId)
        {
            // SEIF SHERIF
            List<Customer_Product> relatedRecords = await dbContext.customer_Products
            .Where(cp => cp.ProductId == ProductId)
            .ToListAsync();
            dbContext.customer_Products.RemoveRange(relatedRecords);
            dbContext.SaveChanges();
            //
            return await baseRepo.DeleteAsync(ProductId);
        }

    }
}
