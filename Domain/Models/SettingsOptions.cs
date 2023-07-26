using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SettingsOptions
    {
        public string? ConnectionStrings { get; set; } = string.Empty;
        public int MaxAnnouncementPerUser { get; set; } = 0;
        public int MaxPageSize { get; set; } = 0;
        public int DefauldPageSize { get; set; } = 0;
    }
}
