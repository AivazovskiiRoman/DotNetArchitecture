using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Applications;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Mapping;
using Solution.CrossCutting.Security;
using Solution.Domain.Domains;
using Solution.Infrastructure.Database;

namespace Solution.CrossCutting.DependencyInjection
{
    public static class DependencyInjector
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static IServiceCollection Services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            Services.AddDbContextPool<T>(options => options.UseSqlServer(connectionString));
            var context = GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
        {
            Services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            GetService<T>().Database.EnsureCreated();
        }

        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            Services = services;

            // Solution.Application.Applications
            Services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            Services.AddScoped<IUserApplication, UserApplication>();

            // Solution.CrossCutting
            Services.AddScoped<ICriptography, Criptography>();
            Services.AddScoped<IHash, Hash>();
            Services.AddScoped<IJsonWebToken, JsonWebToken>();
            Services.AddScoped<ILogger, Logger>();
            Services.AddScoped<IMapper, Mapper>();

            // Solution.Domain.Domains
            Services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
            Services.AddScoped<IUserDomain, UserDomain>();
            Services.AddScoped<IUserLogDomain, UserLogDomain>();

            // Solution.Infrastructure.Database
            Services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
            Services.AddScoped<IUserLogRepository, UserLogRepository>();
            Services.AddScoped<IUserRepository, UserRepository>();

            return Services;
        }
    }
}
