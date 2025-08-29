using System;
using System.ComponentModel.DataAnnotations;

namespace UserSystem.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string UserId { get; set; }

        [Required, StringLength(128)]
        public string Action { get; set; }     

        [StringLength(256)]
        public string Entity { get; set; }     

        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public string IpAddress { get; set; }
    }
}
