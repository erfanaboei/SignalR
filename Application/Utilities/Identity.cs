using System.Security.Claims;

namespace Application.Utilities
{
    public static class Identity
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(userId);
        }
    }
}