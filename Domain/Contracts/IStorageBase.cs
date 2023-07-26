using Domain.Common;
using Domain.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IStorageBase<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<ServiceResult<T>> Get(Guid id);

        Task<ServiceResult<T>> Create(T entity);

        Task<ServiceResult<T>> Update(Guid id, T entity);

        Task<ServiceResult> Delete(Guid id);
    }
}
