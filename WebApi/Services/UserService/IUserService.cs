using Domain.Models.QueryParameters;
using Domain.Models;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;
using Domain.Common;

namespace WebApi.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAll(QueryUserParameters ownerParameters);

        public Task<ServiceResult<UserDto>> GetById(Guid id);

        public Task<ServiceResult<UserDto>> Create(UserForCreationOrUpdateDto entity);

        public Task<ServiceResult<UserDto>> Update(Guid id, UserForCreationOrUpdateDto entity);

        public Task<ServiceResult> Delete(Guid id);
    }
}
