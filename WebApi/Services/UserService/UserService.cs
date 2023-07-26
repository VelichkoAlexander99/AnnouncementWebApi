using AutoMapper;
using Domain.Common;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.QueryParameters;
using Microsoft.Extensions.Options;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;

namespace WebApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserStorage _userStorage;
        private readonly IOptions<SettingsOptions> _options;

        public UserService(
            IMapper mapper,
            IUserStorage userStorage,
            IOptions<SettingsOptions> options)
        {
            _mapper = mapper;
            _userStorage = userStorage;
            _options = options;
        }

        public async Task<IEnumerable<UserDto>> GetAll(QueryUserParameters ownerParameters)
        {
            ownerParameters.CheckAndSetValues(_options);

            var result = await _userStorage.GetAll(ownerParameters);

            return _mapper.Map<IEnumerable<UserDto>>(result);
        }

        public async Task<ServiceResult<UserDto>> GetById(Guid id)
        {
            var result = await _userStorage.Get(id);

            return _mapper.Map<ServiceResult<UserDto>>(result);
        }

        public async Task<ServiceResult<UserDto>> Create(UserForCreationOrUpdateDto entity)
        {
            var userCreate = _mapper.Map<User>(entity);

            var result = await _userStorage.Create(userCreate);

            return _mapper.Map<ServiceResult<UserDto>>(result);
        }

        public async Task<ServiceResult<UserDto>> Update(Guid id, UserForCreationOrUpdateDto entity)
        {
            var userUpdate = _mapper.Map<User>(entity);

            var result = await _userStorage.Update(id, userUpdate);

            return _mapper.Map<ServiceResult<UserDto>>(result);
        }

        public async Task<ServiceResult> Delete(Guid id)
        {
            var result = await _userStorage.Delete(id);

            return result;
        }
    }
}
