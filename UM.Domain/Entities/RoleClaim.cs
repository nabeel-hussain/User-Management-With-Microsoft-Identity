using UM.Domain.Primitives;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UM.Domain.Entities;
public class RoleClaim : IdentityRoleClaim<Guid>, IEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
}

