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
        private readonly User_Repo user_repo;
        private readonly ISuppliersRepo supplier_repo;

        public Product2Controller(ApplicationDbContext dbcontext,IProduct2Repo product_repo,User_Repo user_repo, ISuppliersRepo supplier_repo)
        {
            this.dbcontext = dbcontext;
            this.product_repo = product_repo;
            this.user_repo = user_repo;
            this.supplier_repo = supplier_repo;
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

        [Authorize(Roles = "Customer")]
        public IActionResult Add_To_Cart(int product_id)
        {
            Customer_Product customer_product = new Customer_Product();
            customer_product.CustomerId = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            customer_product.ProductId = product_id;
            bool check = product_repo.AddToCart(customer_product);
            if (check == false)
            {
                TempData["Check"] = "You added this product previously";
            }
            return RedirectToAction("Get_All_Shipped_Product_Of_Customer",ViewBag);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Get_All_Shipped_Product_Of_Customer()
        {
            string customer_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            List<ProductShipped> ListOfProductShipped = product_repo.GetAllShippedProductForCustomer(customer_id);
            return View("GetAllShippedProductOfCustomer", ListOfProductShipped);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Go_To_Buying_Form(int product_id , int supplier_id, string supplier_name, string product_name, decimal product_price , string product_image , string customer_name)
        {
            Buying_Proccess buying_process_model = new Buying_Proccess();
            buying_process_model.product_id = product_id;
            buying_process_model.supplier_id = supplier_id;
            buying_process_model.supplier_name = supplier_name;
            buying_process_model.product_name = product_name;
            buying_process_model.product_price = product_price;
            buying_process_model.product_image = product_image;
            buying_process_model.customer_name = customer_name;
            return View("GoToBuyingForm", buying_process_model);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Buy_Now(Buying_Proccess buying_process_model,int product_id , int supplier_id , string product_image , string customer_name)
        {
            buying_process_model.customer_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            buying_process_model.product_id = product_id;
            buying_process_model.supplier_id = supplier_id;
            buying_process_model.product_image = product_image;
            buying_process_model.customer_name = customer_name;
            product_repo.AddNewBuyingProccess(buying_process_model);
            return RedirectToAction("Get_All_Product_For_Customer");
        }

        public IActionResult Get_All_Product_Shipped_Of_Supplier()
        {
            string supplier_username = User.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
            string supplier_email = User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            ApplicationUser application_user = user_repo.Get_User(supplier_username, supplier_email);
            string supplier_phonenumber = application_user.PhoneNumber;
            int supplier_id = supplier_repo.GetIdOfSupplier(supplier_username,supplier_email,supplier_phonenumber);
            List<Buying_Proccess> buying_proccesses = supplier_repo.GetBuyedProductOfSupplier(supplier_id);
            return View("GetAllShippedProductOfSupplier", buying_proccesses);
        }

        public IActionResult Delete_Product_From_Shipping_Cart(int product_id)
        {
            string customer_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            product_repo.DeleteProductFromShippingCart(customer_id, product_id);
            return RedirectToAction("Get_All_Shipped_Product_Of_Customer");
        }


    }
}
