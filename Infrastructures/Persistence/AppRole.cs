using App;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Persistence
{
    [Table("app_roles")]
    public class AppRole : IdentityRole<long>, IRole
    {
        public static readonly AppRole Empty = new()
        {
            Id = -1,
            ConcurrencyStamp = string.Empty,
            CreatedAt = DateTime.UnixEpoch,
            CreatedBy = -1,
            DeletedAt = DateTime.UnixEpoch,
            DeletedBy = -1,
            Name = string.Empty,
            NormalizedName = string.Empty,
            UpdatedAt = DateTime.UnixEpoch,
            UpdatedBy = -1
        };
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; } = -1;
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; } = -1;
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
