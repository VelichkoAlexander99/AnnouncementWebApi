using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QueryParameters
{
    public class QueryUserParameters : QueryStringParameters
    {
        public string Name { get; set; } = string.Empty;
        public Guid Id { get; set; } = Guid.Empty;

        public override void CheckAndSetValues(IOptions<SettingsOptions> options)
        {
            base.CheckAndSetValues(options);

            OrderBy = nameof(Name);
        }
    }
}
