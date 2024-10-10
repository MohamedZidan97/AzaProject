using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class StockLevel
    {
        public int StockLevelId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
