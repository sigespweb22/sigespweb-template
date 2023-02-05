using System.Linq;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Sigesp.Infra.CrossCutting.Identity.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var hasHttpContextUser = _httpContextAccessor.HttpContext.User.Claims.Count();
            Guid userIdMapped = Guid.Empty;
            try
            {
                String userId = "";
                if (hasHttpContextUser != 0)
                    userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                
                Guid.TryParse(userId, out userIdMapped);
            }
            catch { throw; }
            return userIdMapped;
        }
    }
}