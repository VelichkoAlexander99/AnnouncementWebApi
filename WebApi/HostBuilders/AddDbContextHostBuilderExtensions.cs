using Domain.Models;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WebApi.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static void AddDbContext(this WebApplicationBuilder host)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var options =
                host.Configuration.GetSection("SettingsOptions")
                    .Get<SettingsOptions>();

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            void configureDbContext(DbContextOptionsBuilder o) => o.UseNpgsql(options.ConnectionStrings);

            host.Services.AddDbContext<ApplicationContext>(configureDbContext);
        }
    }
}
