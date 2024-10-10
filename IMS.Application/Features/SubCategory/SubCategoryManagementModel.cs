using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.SubCategory
{
    public class SubCategoryManagementModel
    {
        public class GetSubCategoriesResponse
        {
            public int SubCategoryId { get; set; }
            public string SubCategoryName { get; set; }
        }
    }
}
