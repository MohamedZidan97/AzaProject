using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Domain.View_Model;
using IMS.Persistance;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
// SEIF SHERIF
namespace InventoryManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        ISuppliersRepo supplier_repo;
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly SignInManager<ApplicationUser> signinmanager;

        public SupplierController(ISuppliersRepo supplier_repo,
               UserManager<ApplicationUser> usermanger,
               SignInManager<ApplicationUser> signinmanager)
        {
            this.supplier_repo = supplier_repo;
            this.usermanger = usermanger;
            this.signinmanager = signinmanager;
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

        public async Task<IActionResult> Add_SupplierAsync(Supplier supplier , IFormFile Image)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Images", Image.FileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }
            supplier.Image = Image.FileName;


            ApplicationUser applicationuser = new ApplicationUser();
            applicationuser.FirstName = supplier.SupplierFirstName;
            applicationuser.LastName = supplier.SupplierLastName;
            applicationuser.Email = supplier.Email;
            applicationuser.PasswordHash = supplier.Password;
            applicationuser.PhoneNumber = supplier.PhoneNumber;
            applicationuser.UserName = supplier.UserName;
            IdentityResult CheakCreated = await usermanger.CreateAsync(applicationuser, applicationuser.PasswordHash);
            if (CheakCreated.Succeeded)
                await usermanger.AddToRoleAsync(applicationuser, "Supplier");
            else
            {
                foreach (var error in CheakCreated.Errors)
                {
                    ModelState.AddModelError("ErrorOfAddedUserOperation", error.Description);
                }
            }
            string user_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            supplier_repo.AddSupplier(supplier, user_id);
            return RedirectToAction("Get_All_Suppliers");
        }

        public IActionResult Delete_Supplier(int supplierid)
        {
            Supplier supplier = supplier_repo.GetSupplierById(supplierid);
            ApplicationUser applicationuser = supplier_repo.GetMatchedSupplierInApplicationUser(supplier.UserName);
            supplier_repo.DeleteSupplier(supplierid,applicationuser);
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
            Supplier old_supplier = supplier_repo.GetSupplierById(supplierid); ;
            ApplicationUser applicationuser = supplier_repo.GetMatchedSupplierInApplicationUser(old_supplier.UserName);
            supplier_repo.UpdateSupplier(supplierid, supplier,applicationuser);
            return RedirectToAction("Get_All_Suppliers");
        }
    }
}
