using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Solution.CrossCutting.AspNetCore.Middlewares;
using Solution.CrossCutting.DependencyInjection;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static IHostingEnvironment Environment { get; } = DependencyInjector.GetService<IHostingEnvironment>();

        public static void UseCorsCustom(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowCredentials().AllowAnyHeader().AllowAnyMethod());
        }

        public static void UseExceptionCustom(this IApplicationBuilder application)
        {
            if (Environment.IsDevelopment())
            {
                application.UseDatabaseErrorPage();
                application.UseDeveloperExceptionPage();
            }

            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHstsCustom(this IApplicationBuilder application)
        {
            if (Environment.IsDevelopment())
            {
                return;
            }

            application.UseHsts();
        }

        public static void UseSpaCustom(this IApplicationBuilder application)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (!Environment.IsDevelopment())
                {
                    return;
                }

                spa.UseAngularCliServer("serve");
            });
        }
    }
}
