using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SEIF SHERIF
namespace IMS.Persistance.Repositories.EntitiesRepo
{
    public class User_Repo
    {
        ApplicationDbContext dbcontext;
        public User_Repo(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public ApplicationUser Get_User(string username , string email)
        {
            ApplicationUser? user = dbcontext.ApplicationUsers.SingleOrDefault(user => user.UserName == username && user.Email == email);
            return user;
        }

    }
}
