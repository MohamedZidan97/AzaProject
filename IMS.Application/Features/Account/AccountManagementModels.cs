using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Account
{
    public class AccountManagementModels
    {
        public class AccountRegisterRequest
        {
            [MaxLength(100)]
            public string FirstName { get; set; }

            [MaxLength(100)]
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

           // public string RoleName { get; set; }
        }
        public class AccountLoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }

            public bool RememberMe { get;set; }
        }
        public class AccountGeneralResponse
        {
            public string? Message { get; set; }
            public bool IsAuthenticed { get; set; }
                        public string? PhoneNumber { get; set; }

            public string? Email { get; set; }
            public List<string>? Roles { get; set; }

            public DateTime? ExpiresOn { get; set; }

            public int? VirtualCompanyId { get; set; }
            public string FullName { get; set; }


            //// [JsonIgnore]
            //public string? RefreshToken { get; set; }
            //public DateTime? RefreshTokenExpiration { get; set; }
        }

    }
}
