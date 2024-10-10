using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Product>? Products { get; set; }


    }
}
