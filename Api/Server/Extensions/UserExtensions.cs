using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api.Extensions
{
    public static class UserExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
