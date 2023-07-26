using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QueryParameters
{
    public class QueryAnnouncementParameters : QueryStringParameters
    {
        public int Number { get; set; }
        public int Rating { get; set; }
    }
}
