using IMS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace IMS.Persistance.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public BaseRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<GeneralResponse> AddAsync(T entity)
        {
            var RG = new GeneralResponse();

            try
            {
                await context.Set<T>().AddAsync(entity);

                RG.Done = true;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or set RG.Done to false if needed.
                RG.Done = false;
                RG.Message = $"An error occurred: {ex.Message}";
            }

            return RG;
        }

        public async Task<GeneralResponse> DeleteAsync(int id)
        {

            var item = await context.Set<T>().FindAsync(id);

            if (item != null)
            {
                var check = context.Set<T>().Remove(item);
                await context.SaveChangesAsync();


                return new GeneralResponse { Done = true };
            }

            return new GeneralResponse { Message = "Not Found" };
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var allRows = await context.Set<T>().ToListAsync();
            return allRows;

        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var response = await context.Set<T>().FindAsync(id);
                return response;
            }
            catch (Exception ex)
            {
                return await context.Set<T>().FirstOrDefaultAsync();
            }

        }

        public async Task<GeneralResponse> UpdateAsync(T entity)
        {
            var RG = new GeneralResponse();
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                RG.Done = true; // Return true if the update is successful
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or set RG.Done to false if needed.
                RG.Done = false;
                RG.Message = $"An error occurred: {ex.Message}";
            }

            return RG;
        }


    }
}
