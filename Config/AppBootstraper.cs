using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain;
using Infrastructure;
using Application;
using Microsoft.Extensions.Hosting;


namespace Config
{
    public static class AppBootstraper
    {
        public static IServiceCollection InitApp(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {
            services.AddScoped<IUserService, UserService>();
            InfrastructureBootStraper.RegisterDependency(services, config, env);

            return services;
        }
    }
}
