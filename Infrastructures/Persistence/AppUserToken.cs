using App;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Persistence
{
    [Table("app_user_tokens")]
    public class AppUserToken : IdentityUserToken<long>, IUserToken
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; } = -1;
        public DateTime UpdatedAt { get; set; }
        public long UpdatedBy { get; set; } = -1;
    }
}
