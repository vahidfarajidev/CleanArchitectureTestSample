using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InfrastructureBootStraper
    {
        public static void RegisterDependency(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment env)
        {
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            if (!env.EnvironmentName.Equals("IntegrationTest", StringComparison.OrdinalIgnoreCase))
            {
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            }

        }
    }
}
