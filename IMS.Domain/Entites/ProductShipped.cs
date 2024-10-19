using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class ProductShipped
    {
        public int Product_Id { get; set; }
        public string Product_Image { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Phone { get; set; }
        public string Customer_Name {  get; set; }

    }
}
