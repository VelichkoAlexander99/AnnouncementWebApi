using Domain.Common;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.QueryParameters;
using EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Storage
{
    public class UserStorage : IUserStorage
    {
        private readonly ApplicationContext _context;

        public UserStorage(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll(QueryUserParameters query)
        {
            var users = _context.Set<User>()
                .AsNoTracking();           

            users.Paging(
                query.PageNumber,
                query.PageSize);

            return await users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ServiceResult<User>> Get(Guid id)
        {
            User? item = await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync((e) => e.Id.Equals(id));

            if (item == null)
                return ServiceResult<User>.Fail($"User with Id '{id}' not found");

            return ServiceResult<User>.Success(item);
        }

        public async Task<ServiceResult<User>> Create(User entity)
        {
            var createdItem = await _context.AddAsync<User>(entity);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(createdItem.Entity);
        }

        public async Task<ServiceResult<User>> Update(Guid id, User entity)
        {
            User? user = await _context.Set<User>()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));

            if (user == null)
                return ServiceResult<User>.Fail($"User with Id '{id}' not found");

            user.IsAdmin = entity.IsAdmin;
            user.Name = entity.Name;

            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(user);
        }

        public async Task<ServiceResult> Delete(Guid id)
        {
            User? entity = await _context.Set<User>()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));

            if (entity == null)
                return ServiceResult.Fail($"User with Id '{id}' not found");

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return ServiceResult.Success;
        }
    }
}
