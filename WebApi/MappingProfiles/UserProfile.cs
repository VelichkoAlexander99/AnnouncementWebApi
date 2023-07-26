using Domain.Models;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;
using AutoMapper;

namespace WebApi.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
            .ConstructUsing(x => new UserDto()
            {
                Id = x.Id,
                IsAdmin = x.IsAdmin,
                Name = x.Name
            });

            CreateMap<UserDto, User>()
            .ConstructUsing(x => new User()
            {
                Id = x.Id,
                IsAdmin = x.IsAdmin,
                Name = x.Name
            });

            CreateMap<UserForCreationOrUpdateDto, User>()
            .ConstructUsing(x => new User()
            {
                IsAdmin = x.IsAdmin,
                Name = x.Name
            });
        }
    }
}