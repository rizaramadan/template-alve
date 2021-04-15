using App;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Persistence
{
    [Table("app_role_claims")]
    public class AppRoleClaim : IdentityRoleClaim<long>, IRoleClaim
    {
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; } = -1;
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; } = -1;
    }
}
