using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public Uri? ImageUri { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expity { get; set; }


        //Navigation prop
        public virtual User? User { get; set; }
    }
}
