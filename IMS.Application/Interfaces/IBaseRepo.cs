using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace IMS.Application.Interfaces
{
    public interface IBaseRepo<T>
    {
        // Add
        Task<GeneralResponse> AddAsync(T entity);

        // Read
        Task<T> GetByIdAsync(int id);

        // Get all By Id

        //  Task<IEnumerable<T>> GetAllByIdAsync(int id);

        // Get all
        Task<IEnumerable<T>> GetAllAsync();

        // Update
        Task<GeneralResponse> UpdateAsync(T entity);

        // Delete
        Task<GeneralResponse> DeleteAsync(int id);


    }
}
