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
    public class Buying_Proccess
    {
        [Key]
        public int buying_id { get; set; }

        [ForeignKey("application_user")]
        public string customer_id { get; set; }
        public ApplicationUser application_user { get; set; }

        [ForeignKey("supplier")]
        public int supplier_id {  get; set; }
        public Supplier supplier { get; set; }
        public string supplier_name { get; set; }

        [ForeignKey("product")]
        public int product_id { get; set; }
        public Product product { get; set; }
        public string product_name { get; set; }
        public decimal product_price { get; set; }
        public string product_image { get; set; }

        [Required]
        [Display(Name ="Enter Your Phone")]
        public string customer_phone { get; set; }

        public string customer_name { get; set; }

        [Required]
        [Display(Name = "Enter Your Address In Details")]
        public string customer_address { get; set; }
    }
}
