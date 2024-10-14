using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
// SEIF SHERIF
namespace InventoryManagementSystem.Controllers
{
    public class Product2Controller : Controller
    {
        ApplicationDbContext dbcontext;
        private readonly IProduct2Repo product_repo;

        public Product2Controller(ApplicationDbContext dbcontext, IProduct2Repo product_repo)
        {
            this.dbcontext = dbcontext;
            this.product_repo = product_repo;
        }

        public IActionResult Get_All_Product_Of_Current_User()
        {
            string user_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            List<Product_Details_ViewModel> product_Details = product_repo.GetAllProductOfCurrentUser(user_id);
            return View("GetAllProduct", product_Details); 
        }
    }
}
