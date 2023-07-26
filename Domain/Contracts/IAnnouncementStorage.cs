using Domain.Models;
using Domain.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAnnouncementStorage : IStorageBase<Announcement>
    {
        Task<IEnumerable<Announcement>> GetAll(QueryAnnouncementParameters query);
    }
}
