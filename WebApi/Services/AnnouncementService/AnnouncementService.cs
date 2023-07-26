using AutoMapper;
using Domain.Common;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.QueryParameters;
using EntityFramework.Storage;
using Microsoft.Extensions.Options;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;

namespace WebApi.Services.AnnouncementService
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementStorage _announcementStorage;
        private readonly IOptions<SettingsOptions> _options;

        public AnnouncementService(
            IMapper mapper, 
            IAnnouncementStorage announcementStorage, 
            IOptions<SettingsOptions> options)
        {
            _mapper = mapper;
            _announcementStorage = announcementStorage;
            _options = options;
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAll(QueryAnnouncementParameters ownerParameters)
        {
            ownerParameters.CheckAndSetValues(_options);

            var result = await _announcementStorage.GetAll(ownerParameters);

            return _mapper.Map<IEnumerable<AnnouncementDto>>(result);
        }

        public async Task<ServiceResult<AnnouncementDto>> GetById(Guid id)
        {
            var result = await _announcementStorage.Get(id);

            return _mapper.Map<ServiceResult<AnnouncementDto>>(result);
        }

        public async Task<ServiceResult<AnnouncementDto>> Create(AnnouncementForCreationDto entity)
        {
            var announcementCreate = _mapper.Map<Announcement>(entity);

            var result = await _announcementStorage.Create(announcementCreate);

            return _mapper.Map<ServiceResult<AnnouncementDto>>(result);
        }

        public async Task<ServiceResult<AnnouncementDto>> Update(Guid id, AnnouncementForUpdateDto entity)
        {
            var announcementUpdate = _mapper.Map<Announcement>(entity);

            var result = await _announcementStorage.Update(id, announcementUpdate);

            return _mapper.Map<ServiceResult<AnnouncementDto>>(result);
        }

        public async Task<ServiceResult> Delete(Guid id)
        {
            var result = await _announcementStorage.Delete(id);

            return result;
        }
    }
}
