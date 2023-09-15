
using UM.Domain.Constants;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace UM.Infrastructure.Authentication;

public static class PrincipalExtentions
{
    public static List<string> GetPermissions(this IPrincipal principal)
    {
        var cliamsPrincipal = principal as ClaimsPrincipal;
        if (cliamsPrincipal != null)
        {
            return cliamsPrincipal.Claims.Where(x => x.Type == CustomClaimTypes.Permissions).Select(x => x.Value).ToList();
        }
        else
        {
            return new List<string>();
        }
    }
    public static bool IsPermissionAllowed(this IPrincipal principal, string permission)
    {

        var cliamsPrincipal = principal as ClaimsPrincipal;

        if (cliamsPrincipal != null)
        {
            return cliamsPrincipal.HasClaim(CustomClaimTypes.Permissions, permission);
        }
        else
        {
            return false;
        }

    }
    public static Guid? UserId(this IPrincipal principal)
    {
        var cliamsPrincipal = principal as ClaimsPrincipal;

        if (cliamsPrincipal != null)
        {
            Guid temp;
            if (Guid.TryParse(cliamsPrincipal.FindFirst(CustomClaimTypes.UserId)?.Value, out temp))
            {
                return temp;
            }
            else
            {
                return null;
            }

        }
        return null;
    }
}
