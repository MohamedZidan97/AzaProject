using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class Product_Details_ViewModel
    {
        public string Supplier_Name { get; set; }
        public string Product_Image { get; set; }
        public string Product_Name { get; set; }  
        public int Product_Stock { get; set; }
        public int Product_Low_Stock { get; set; }

    }
}
