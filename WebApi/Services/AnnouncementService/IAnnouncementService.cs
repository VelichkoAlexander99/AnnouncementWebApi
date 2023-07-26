using Domain.Models.QueryParameters;
using Domain.Models;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;
using Domain.Common;

namespace WebApi.Services.AnnouncementService
{
    public interface IAnnouncementService
    {
        public Task<IEnumerable<AnnouncementDto>> GetAll(QueryAnnouncementParameters ownerParameters);

        public Task<ServiceResult<AnnouncementDto>> GetById(Guid id);

        public Task<ServiceResult<AnnouncementDto>> Create(AnnouncementForCreationDto entity);

        public Task<ServiceResult<AnnouncementDto>> Update(Guid id, AnnouncementForUpdateDto entity);

        public Task<ServiceResult> Delete(Guid id);
    }
}
