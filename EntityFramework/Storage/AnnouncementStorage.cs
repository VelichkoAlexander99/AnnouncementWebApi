using Domain.Common;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.QueryParameters;
using Domain.Validations;
using EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Storage
{
    public class AnnouncementStorage : IAnnouncementStorage
    {
        private readonly ApplicationContext _context;
        private readonly IOptions<SettingsOptions> _options;

        public AnnouncementStorage(
            ApplicationContext context,
            IOptions<SettingsOptions> options)
        {
            _context = context;
            _options = options;
        }

        public async Task<IEnumerable<Announcement>> GetAll(QueryAnnouncementParameters query)
        {
            var users = _context.Set<Announcement>()
                .AsNoTracking();

            users.Paging(
                query.PageNumber,
                query.PageSize);

            return await users.ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await _context.Set<Announcement>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ServiceResult<Announcement>> Get(Guid id)
        {
            Announcement? item = await _context.Set<Announcement>()
                                .FirstOrDefaultAsync((e) => e.Id == id);
            if (item == null)
                return ServiceResult<Announcement>.Fail($"Announcement with Id '{id}' not found");

            return ServiceResult<Announcement>.Success(item);
        }

        public async Task<ServiceResult<Announcement>> Create(Announcement entity)
        {
            if (!await _context.Set<User>().AnyAsync(item => item.Id == entity.UserId))
                return ServiceResult<Announcement>.Fail($"User with Id '{entity.UserId}' not found");

            var countAnnouncementForPerson = await _context.Set<Announcement>()
                    .CountAsync(e => e.UserId == entity.UserId);
            if (countAnnouncementForPerson >= _options.Value.MaxAnnouncementPerUser)
                return ServiceResult<Announcement>.Fail($"The maximum number of announcement per user {_options.Value.MaxAnnouncementPerUser}");

            var createdItem = await _context.AddAsync<Announcement>(entity);
            await _context.SaveChangesAsync();

            return ServiceResult<Announcement>.Success(createdItem.Entity);
        }

        public async Task<ServiceResult<Announcement>> Update(Guid id, Announcement entity)
        {
            Announcement? item = await _context.Set<Announcement>()
                .FirstOrDefaultAsync(item => item.Id == id);

            if (item == null)
                return ServiceResult<Announcement>.Fail($"Announcement with Id '{id}' not found");

            item.Text = entity.Text;
            item.ImageUri = entity.ImageUri;
            item.Rating = entity.Rating;
            item.Created = entity.Created;
            item.Expity = entity.Expity;

            _context.Set<Announcement>().Update(item);
            await _context.SaveChangesAsync();

            return ServiceResult<Announcement>.Success(item);
        }

        public async Task<ServiceResult> Delete(Guid id)
        {
            Announcement? entity = await _context.Set<Announcement>()
                .FirstOrDefaultAsync(item => item.Id == id);

            if (entity == null)
                return ServiceResult.Fail($"Announcement with Id '{id}' not found");

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return ServiceResult.Success;
        }
    }
}
