using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Domain.Entites
{
    public class User_Supplier
    {
        [ForeignKey("applicaion_user")]
        public string UserId { get; set; }
        public ApplicationUser applicaion_user {  get; set; }

        [ForeignKey("supplier")]
        public int SupplierId { get; set; }
        public Supplier supplier { get; set; }
    }

}


