using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Account.AccountManagementModels;

namespace IMS.Application.Interfaces
{
    public interface IAuthServices
    {
        Task<AccountGeneralResponse> RegisterAsync(AccountRegisterRequest request);

        Task<AccountGeneralResponse> LoginAsync(AccountLoginRequest request);

        // Task<string> AddRoleAsync(AddRoleM roleM);

        //Task<AccountGeneralResponse> CheckOrCreateRefreshTokenAsync(string refreshToken);

        // if you want Revoked for token is active, use this method
        //Task<bool> RevokedTokenAsync(string refreshToken);
    }
}
