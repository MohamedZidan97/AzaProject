using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Must Be Less Than 50 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 2 Letters")]
        [RegularExpression(@"^[a-z A-Z 0-9 \s]+$", ErrorMessage = "Must Be Letters And Number Only")]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Contact Info")]
        [MaxLength(100, ErrorMessage = "Must Be Less Than 100 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 3 Letters")]
        public string ContactInfo { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
