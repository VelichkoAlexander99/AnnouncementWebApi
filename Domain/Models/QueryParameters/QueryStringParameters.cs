using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QueryParameters
{
    public class QueryStringParameters
    {
        #region PageSize

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; }

        #endregion

        #region OrderBy

        public string OrderBy { get; set; } = string.Empty;

        #endregion

        public virtual void CheckAndSetValues(IOptions<SettingsOptions> options)
        {
            if (PageNumber == 0)
                PageNumber = 1;

            if (PageSize == 0)
                PageSize = options.Value.DefauldPageSize;

            if (PageSize > options.Value.MaxPageSize)
                PageSize = options.Value.MaxPageSize;
        }
    }
}
