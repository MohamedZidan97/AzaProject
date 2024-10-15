using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Security.Claims;
// SEIF SHERIF
namespace InventoryManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext dbcontext;
        private readonly IProduct2Repo product_repo;

        public DashboardController(ApplicationDbContext dbcontext, IProduct2Repo product_repo)
        {
            this.dbcontext = dbcontext;
            this.product_repo = product_repo;
        }
        public IActionResult Get_All_Product_Of_Low_Level()
        {
            string user_id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            List<Product_Details_ViewModel> product_Details = product_repo.GetAllProductOfLowLevel(user_id);
            return View("GetAllProductOfLowLevel", product_Details);
        }

        public IActionResult Go_To_Report_Form(int supplier_id, string supplier_name ,string supplier_username, string product_name)
        {
            Report report = new Report();
            report.SupplierId = supplier_id;
            report.Supplier_Name = supplier_name;
            report.Supplier_UserName = supplier_username;
            report.Product_Name = product_name;
            report.UserId = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            return View("GoToReportForm", report);
        }
        public IActionResult Add_Report(Report report, string user_id)
        {
            report.UserId = user_id;
            dbcontext.Reports.Add(report);
            dbcontext.SaveChanges();
            return RedirectToAction("Get_All_Reports_Admin");
        }

        [Authorize(Roles = "Supplier")]
        public IActionResult Get_All_Reports_Supplier()
        {
            string Supplier_User_Name = User.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
            var list = from report in dbcontext.Reports
                       join application_user in dbcontext.ApplicationUsers on report.UserId equals application_user.Id
                       where report.Supplier_UserName == Supplier_User_Name
                       select new Report_Details_ModelView
                       {
                           Product_Name = report.Product_Name,
                           product_Description = report.Discription,
                           Reporter_Name = application_user.FirstName + " " + application_user.LastName
                       };
            return View("GoToReportCard",list.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Get_All_Reports_Admin()
        {
            var list = (from report in dbcontext.Reports
                       join application_user in dbcontext.ApplicationUsers on report.UserId equals application_user.Id
                       select new Report_Details_ModelView
                       {
                           Report_Id = report.Report_Id,
                           Product_Name = report.Product_Name,
                           product_Description = report.Discription,
                           Reported_Name = report.Supplier_Name,
                       }).ToList();

            List<Product> products = new List<Product>();
            List<bool> flags = new List<bool>();
            foreach (var item in list)
            {
                Product? product = dbcontext.products.SingleOrDefault(prod=>prod.ProductName == item.Product_Name);
                if(product != null && product.Stock > product.LowStock)
                {
                    products.Add(product);
                    flags.Add(true);
                }
                if (product != null && product.Stock <= product.LowStock)
                {
                    products.Add(product);
                    flags.Add(false);
                }
                ViewBag.Flags = flags;
            }
            return View("GoToReportCard",list);
        }

        public IActionResult Delete_Report(int report_id)
        {
            Report report = dbcontext.Reports.SingleOrDefault(rep => rep.Report_Id == report_id) ?? new Report();
            dbcontext.Reports.Remove(report);
            dbcontext.SaveChanges();
            return RedirectToAction("Get_All_Reports_Admin");
        }
    }
}
