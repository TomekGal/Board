using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Board.Persistence.Extension
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
