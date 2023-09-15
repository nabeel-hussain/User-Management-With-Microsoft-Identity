using UM.Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace UM.Domain.Entities;

public class UserClaim : IdentityUserClaim<Guid>, IEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
}




