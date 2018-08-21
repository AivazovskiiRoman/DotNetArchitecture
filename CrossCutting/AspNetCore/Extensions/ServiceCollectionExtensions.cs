using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthenticationCustom(this IServiceCollection services)
        {
            var jsonWebToken = DependencyInjector.GetService<IJsonWebToken>();

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddMvcCustom(this IServiceCollection services)
        {
            void Mvc(MvcOptions mvc)
            {
                mvc.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }

            void Json(MvcJsonOptions json)
            {
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            services.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddSpaStaticFilesCustom(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
        }
    }
}
