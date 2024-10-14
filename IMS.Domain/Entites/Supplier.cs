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
        [Display(Name = "Fisrt Name")]
        [MaxLength(50, ErrorMessage = "Must Be Less Than 50 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 2 Letters")]
        [RegularExpression(@"^[a-z A-Z \s]+$", ErrorMessage = "Must Be Letters")]
        public string SupplierFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Must Be Less Than 50 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 2 Letters")]
        [RegularExpression(@"^[a-z A-Z \s]+$", ErrorMessage = "Must Be Letters")]
        public string SupplierLastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [MaxLength(50, ErrorMessage = "Must Be Less Than 50 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 2 Letters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Must Be Less Than 50 Letters")]
        [MinLength(3, ErrorMessage = "Must Be More Than 2 Letters")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Must Be Number Only")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public ICollection<Product>? Products { get; set; }
    }
}
