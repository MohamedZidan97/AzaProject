using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public int LowStock { get; set; }
        public string? Image { get; set; }
        public virtual string ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public virtual ICollection<StockLevel>? StockLevels { get; set; }
    }
}
