using IMS.Application.Features.Account;
using IMS.Application.Interfaces;
using IMS.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Account.AccountManagementModels;

namespace IMS.Persistance.Repositories
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthServices(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<AccountGeneralResponse> LoginAsync(AccountLoginRequest request)
        {
            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
            if (result.Succeeded)
                return new AccountGeneralResponse { IsAuthenticed=true };

            return new AccountGeneralResponse { Message = "Enter Email And Password are Valid." };

        }

        public async Task<AccountGeneralResponse> RegisterAsync(AccountRegisterRequest request)
        {
            var User = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber

            };
            var result = await userManager.CreateAsync(User, request.Password);

            if (result.Succeeded)
            {
               await userManager.AddToRoleAsync(User, "Admin");

                return new AccountGeneralResponse { IsAuthenticed = true };
            }

            return  new AccountGeneralResponse { Message = "Found Error!" };

        }
    }
}
