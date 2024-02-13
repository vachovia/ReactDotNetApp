

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;

namespace ReactDotNetApp.Middlewares.Services
{
    public static class IdentityMiddleware
    {
        public static IServiceCollection UseAppIdentityContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("AzureSql"));
            });
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 1;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //});

            return services;
        }
    }
}
