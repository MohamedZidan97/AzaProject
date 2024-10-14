using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Domain.View_Model;
using IMS.Persistance;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
// SEIF SHERIF
namespace InventoryManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        ISuppliersRepo supplier_repo;

        public SupplierController(ISuppliersRepo supplier_repo)
        {
            this.supplier_repo = supplier_repo;
        }

        public IActionResult Get_All_Suppliers()
        {
            string user_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            List<Supplier_Details_ViewModel> list = supplier_repo.GetAllSupplier(user_id);
            return View("GetAllSuppliers",list);
        }

        public IActionResult Go_To_Add_Supplier_Form()
        {
            return View("GoToAddSupplierForm");
        }

        public IActionResult Add_Supplier(Supplier supplier , IFormFile Image)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Images", Image.FileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }
            supplier.Image = Image.FileName;

            string user_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            supplier_repo.AddSupplier(supplier, user_id);
            return RedirectToAction("Get_All_Suppliers");
        }

        public IActionResult Delete_Supplier(int supplierid)
        {
            supplier_repo.DeleteSupplier(supplierid);
            return RedirectToAction("Get_All_Suppliers");
        }

        public IActionResult Go_To_Update_Supplier_Form(int supplierid)
        {
            Supplier supplier = supplier_repo.GetSupplierById(supplierid);
            return View("GoToUpdateSupplierForm",supplier);
        }

        public IActionResult Update_Supplier(Supplier supplier, IFormFile Image , int supplierid)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Images", Image.FileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }
            supplier.Image = Image.FileName;
            supplier_repo.UpdateSupplier(supplierid, supplier);
            return RedirectToAction("Get_All_Suppliers");
        }
    }
}
