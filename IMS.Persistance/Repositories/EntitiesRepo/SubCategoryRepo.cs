using IMS.Application.Interfaces;
using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.SubCategory.SubCategoryManagementModel;

namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class SubCategoryRepo : ISubCategoryRepo
    {
        private readonly IBaseRepo<SubCategory> baseRepo;

        public SubCategoryRepo(IBaseRepo<SubCategory> baseRepo)
        {
            this.baseRepo = baseRepo;
        }

        public async Task<IEnumerable<GetSubCategoriesResponse>> GetSubCategoriesRepo()
        {
            var subcats =  (await baseRepo.GetAllAsync()).Select(e =>
            new GetSubCategoriesResponse { SubCategoryId = e.SubCategoryId, SubCategoryName = e.Name })
                .ToList();

           
            return subcats;

        }
    }
}
