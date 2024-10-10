using IMS.Application.Interfaces;
using IMS.Application.Interfaces.IEntitiesRepo;
using IMS.Domain.Entites;
using IMS.Persistance.Repositories;
using IMS.Persistance.Repositories.EntitiesRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Persistance
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("connectionString")));

            #region Email 

            //services.Configure<OutlookMailSettings>(configuration.GetSection("MailSetting"));
            //services.AddScoped<IEmailServices, EmailServices>();

            #endregion

            //// DI

            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddScoped<IAuthServices, AuthServices>();

            //// Repo
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();




            //// DI Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(
               options =>
               {
                   // Default Password settings.
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequiredLength = 3;
                   options.Password.RequiredUniqueChars = 0;
               }
               ).AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);





         


            // Json
            //services.AddControllers().AddJsonOptions(
            //    options =>
            //    {
            //        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //    });

            //services.AddControllers().AddNewtonsoftJson(
            //    options =>
            //    {
            //        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //    });


            return services;

        }
    }
}

