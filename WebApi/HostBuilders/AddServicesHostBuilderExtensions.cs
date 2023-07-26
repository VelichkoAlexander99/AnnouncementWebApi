using Domain.Contracts;
using EntityFramework.Storage;
using WebApi.Services.AnnouncementService;
using WebApi.Services.UserService;

namespace WebApi.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder host)
        {
            host.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            host.Services.AddScoped<IUserStorage, UserStorage>();
            host.Services.AddScoped<IAnnouncementStorage, AnnouncementStorage>();

            host.Services.AddScoped<IUserService, UserService>();
            host.Services.AddScoped<IAnnouncementService, AnnouncementService>();
        }
    }
}
