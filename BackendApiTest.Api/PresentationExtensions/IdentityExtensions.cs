using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace BackendApiTest.Api.PresentationExtensions
{
    public static class IdentityExtensions
    {
        public static long GetCurrentPersonId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt64(data.Value);
            }

            return default(long);
        }
        public static long? GetNullableCurrentPersonId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt64(data.Value);
            }
            return null;
        }

        public static long GetCurrentPersonId(this IPrincipal principal)
        {
            var Person = (ClaimsPrincipal)principal;
            return Person.GetCurrentPersonId();
        }

        public static long? GetNullableCurrentPersonId(this IPrincipal principal)
        {
            var Person = (ClaimsPrincipal)principal;
            return Person.GetNullableCurrentPersonId();
        }
    }
}
