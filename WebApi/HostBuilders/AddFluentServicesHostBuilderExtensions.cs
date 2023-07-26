using Domain.Contracts;
using EntityFramework.Storage;
using FluentValidation;
using FluentValidation.AspNetCore;
using WebApi.Validations;

namespace WebApi.HostBuilders
{
    public static class AddFluentServicesHostBuilderExtensions
    {
        public static void AddFluentServices(this WebApplicationBuilder host)
        {
            host.Services.AddValidatorsFromAssemblyContaining<AnnouncementForCreationDtoValidator>();
            host.Services.AddValidatorsFromAssemblyContaining<AnnouncementForUpdateDtoValidator>();
            host.Services.AddValidatorsFromAssemblyContaining<UserForCreationOrUpdateDtoValidator>();
            host.Services.AddFluentValidationAutoValidation();
            host.Services.AddFluentValidationClientsideAdapters();
        }
    }
}
