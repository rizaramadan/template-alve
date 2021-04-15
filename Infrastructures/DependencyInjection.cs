using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using Infrastructures.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static void AddInfrastructures(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
               options
                   .UseNpgsql(
                       config.GetConnectionString("DefaultConnection"))
                   .UseSnakeCaseNamingConvention()
           );
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
        }
    }
}
