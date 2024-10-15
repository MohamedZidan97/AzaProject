using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class Report
    {
        [Key]
        public int Report_Id { get; set; }

        [ForeignKey("applicaion_user")]
        public string UserId { get; set; }
        public ApplicationUser applicaion_user { get; set; }

        [ForeignKey("supplier")]
        public int SupplierId { get; set; }
        public Supplier supplier { get; set; }

        public string Supplier_Name { get; set; }
        public string Supplier_UserName { get; set; }
        public string Product_Name { get; set; }
        public string Discription {  get; set; }

    }
}

