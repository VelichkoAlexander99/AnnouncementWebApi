using Domain.Models;

namespace WebApi.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static void AddConfiguration(this WebApplicationBuilder host)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(host.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            host.Configuration.AddConfiguration(builder.Build());

            host.Services.AddOptions<SettingsOptions>()
                    .Bind(host.Configuration.GetSection("SettingsOptions"))
                    .ValidateDataAnnotations();
        }
    }
}
