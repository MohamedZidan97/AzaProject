using IMS.Domain.Entites;
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

    }
}
