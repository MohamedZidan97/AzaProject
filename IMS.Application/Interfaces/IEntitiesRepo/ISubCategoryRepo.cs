using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.SubCategory.SubCategoryManagementModel;

namespace IMS.Application.Interfaces.IEntitiesRepo
{
    public interface ISubCategoryRepo
    {
        Task<IEnumerable<GetSubCategoriesResponse>> GetSubCategoriesRepo();
    }
}
