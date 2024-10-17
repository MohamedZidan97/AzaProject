using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class ProductShipped
    {
        public string Product_Image { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Phone { get; set; }

    }
}
