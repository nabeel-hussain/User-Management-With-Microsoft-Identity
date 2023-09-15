using UM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace UM.Infrastructure.Authentication;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString())
    {
    }
}
