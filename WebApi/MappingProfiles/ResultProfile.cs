using AutoMapper;
using Domain.Common;
using Domain.Models;
using WebApi.DTOs.Outgoing;

namespace WebApi.MappingProfiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap(typeof(ServiceResult<>), typeof(ServiceResult<>));
        }
    }
}
