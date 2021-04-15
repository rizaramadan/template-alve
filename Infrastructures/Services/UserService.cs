using System.Security.Claims;
using App.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructures.Persistence
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetCurrentUserId()
        {
            string? userIdStr = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userIdStr) && long.TryParse(userIdStr, out long result))
            {
                return result;
            }
            else
            {
                return -1L;
            }
        }
    }
}
