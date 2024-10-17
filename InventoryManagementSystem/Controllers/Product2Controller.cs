using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Authorization;
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
            return View("GetAllProductOfCurrentUser", product_Details); 
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Get_All_Product_For_Customer()
        {
            List<Product> ListOfAllProducts = product_repo.GetAllProductForCustomer();
            return View("GetAllProductForCustomer",ListOfAllProducts);
        }

        public IActionResult Add_To_Cart(int product_id)
        {
            Customer_Product customer_product = new Customer_Product();
            customer_product.CustomerId = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            customer_product.ProductId = product_id;
            product_repo.AddToCart(customer_product);
            return RedirectToAction("Get_All_Product_For_Customer");
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Get_All_Shipped_Product_For_Customer()
        {
            string customer_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            List<ProductShipped> ListOfProductShipped = product_repo.GetAllShippedProductForCustomer(customer_id);
            return View("GetAllShippedProductForCustomer", ListOfProductShipped);
        }

    }
}
