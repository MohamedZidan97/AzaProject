using IMS.Application.Interfaces;
using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance;
using IMS.Persistance.Helper;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace InventoryManagementSystem.Controllers.ProductEndpoints
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ISubCategoryRepo subCategoryRepo;
        private readonly ISupplierRepo supplierRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductRepo repo;
        public ProductController(ISubCategoryRepo subCategoryRepo,ISupplierRepo supplierRepo, 
            UserManager<ApplicationUser> userManager,IProductRepo repo)
        {
            this.subCategoryRepo = subCategoryRepo;
            this.supplierRepo = supplierRepo;
            this.userManager = userManager;
            this.repo = repo;
        }

       private async Task<string> CheckAuth()
        {
            ApplicationUser user = await userManager.GetUserAsync(User);

            return user.Id;

        }

        public async Task<IActionResult> GetAllProducts()
        {

          

            var products = await repo.GetAllProductsAsync(await CheckAuth());
           

          
          

            return View(products);

        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest product)
        {
            if (ModelState.IsValid)
            {
                product.ApplicationUserId = await CheckAuth();
                await repo.AddProductAsync(product);
                return RedirectToAction(nameof(GetAllProducts));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int ProductId)
        {
            // Fetch product from the repository
            var product = await repo.GetProductByIdAsync(ProductId);

            if (product == null)
            {
                return NotFound();
            }

            // Create a model for the view with the existing product data
            var model = new UpdateProductRequest
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                LowStock = product.LowStock,
                SubCategoryId = product.SubCategoryId,
                SupplierId = product.SupplierId,
                ApplicationUserId = await CheckAuth()
            };
            

            // Populate dropdowns if necessary (for example, subcategories or suppliers)
            ViewBag.SubCategories = new SelectList(await subCategoryRepo.GetSubCategoriesRepo(), "SubCategoryId", "SubCategoryName");
            ViewBag.Suppliers = new SelectList(await supplierRepo.GetSuppliersRepo(), "SupplierId", "SupplierName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest model)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload if there is a photo
                
                var res = await repo.UpdateProductAsync(model);

                if(res.Done)
                return RedirectToAction(nameof(GetAllProducts)); // Redirect to a list or details page after update


               
            }

            // Repopulate dropdowns if validation fails
            ViewBag.SubCategories = new SelectList(await subCategoryRepo.GetSubCategoriesRepo(), "SubCategoryId", "SubCategoryName");
            ViewBag.Suppliers = new SelectList(await supplierRepo.GetSuppliersRepo(), "SupplierId", "SupplierName");

            return View(model);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repo.DeleteProductAsync(id);

            return RedirectToAction(nameof(GetAllProducts)); // Redirect to a list or details page after update

        }



        public async Task<IActionResult> Details(int id)
        {
            var product = await repo.GetProductByIdAsync(id);
            if (product == null)
            {

                return RedirectToAction(nameof(GetAllProducts));
            }
            return View(product);
        }
    }
}
