using App;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Persistence
{
    [Table("app_users")]
    public class AppUser : IdentityUser<long>, IUser
    {
        public static readonly AppUser Empty = new()
        {
            Id = -1,
            Name = string.Empty,
            CreatedAt = DateTime.UnixEpoch,
            CreatedBy = -1,
            UpdatedAt = DateTime.UnixEpoch,
            UpdatedBy = -1,
            DeletedAt = DateTime.UnixEpoch,
            DeletedBy = -1
        };

        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; } = -1;
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; } = -1;
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
