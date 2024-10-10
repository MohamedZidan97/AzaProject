using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


           // services.AddScoped<IProductServices, ProductServices>();
            //services.AddScoped<IEmployeesManagementService, EmployeesManagementService>();
            //services.AddScoped<IDepartmentService, DepartmentService>();
            //services.AddScoped<ITaskManagementService, TaskManagementService>();

            //services.AddScoped<ITaskExecutionService, TaskExecutionService>();

            //services.AddScoped<IChatService, ChatService>();

            //services.AddScoped<IHelpAndSupportService, HelpAndSupportService>();

            //services.AddScoped<IPaymentManagementService, PaymentManagementService>();

            return services;
        }
    }
}
