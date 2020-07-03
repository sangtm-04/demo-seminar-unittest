using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using CustomerManagement.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Helpers
{
    public static class StartupHelpers
    {
        public static void AddServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<ILoggingService, TestableLoggerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
        }
    }
}
