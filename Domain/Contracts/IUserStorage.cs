using Domain.Models;
using Domain.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserStorage : IStorageBase<User>
    {
        Task<IEnumerable<User>> GetAll(QueryUserParameters query);
    }
}
