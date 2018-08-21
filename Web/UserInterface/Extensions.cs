using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Database;

namespace Solution.Web.UserInterface
{
    public static class Extensions
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyInjector.RegisterServices(services);
            DependencyInjector.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
            DependencyInjector.GetService<DatabaseContext>().Seed();
        }
    }
}
