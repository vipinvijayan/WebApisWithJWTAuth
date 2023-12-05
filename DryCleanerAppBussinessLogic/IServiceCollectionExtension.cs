using DryCleanerAppDataAccess.IRepository;
using DryCleanerAppDataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanerAppBussinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryDependecies(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(ISecurityRepository), typeof(SecurityRepository));
            return services;
        }

    }
}
