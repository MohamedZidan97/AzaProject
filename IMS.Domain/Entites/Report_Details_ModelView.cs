using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class Report_Details_ModelView
    {
        public int Report_Id { get; set; }
        public int supplier_Id {  get; set; }
        public string Product_Name { get; set; }
        public string product_Description { get; set; }
        public string Reported_Name { get; set; }
        public string Reporter_Name { get; set; }

    }
}
