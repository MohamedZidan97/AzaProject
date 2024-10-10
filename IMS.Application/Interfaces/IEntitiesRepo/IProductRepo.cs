using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace IMS.Application.Interfaces.IEntitiesRepo
{
    public interface IProductRepo
    {
        Task<IQueryable<GetProductsResponse>> GetAllProductsAsync(string UserId);
        Task<GeneralResponse> AddProductAsync(AddProductRequest request);
        Task<GetProductByIdResponse> GetProductByIdAsync(int ProductId);

        Task<GeneralResponse> UpdateProductAsync(UpdateProductRequest request);
        Task<GeneralResponse> DeleteProductAsync(int ProductId);


    }
}
