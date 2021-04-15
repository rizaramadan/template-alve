using App;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Persistence
{
    [Table("app_user_roles")]
    public class AppUserRole : IdentityUserRole<long>, IUserRole
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; } = -1;
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; } = -1;
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
