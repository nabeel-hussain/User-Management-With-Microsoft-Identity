using Microsoft.AspNetCore.Identity;
using UM.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using UM.Domain.Primitives;

namespace UM.Domain.Entities;

public class Role : IdentityRole<Guid>,IEntity
{
   
    public string? Description { get; set; }
    public RoleStatus Status { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public Guid HotelId { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public static Role CreateRole(string roleName, string? description, RoleStatus status,  Guid hotelId)
    {
        Role role = new Role
        {
            Id = Guid.NewGuid(),
            Name= roleName,
            Description = description,
            Status = status,
            CreationDate = DateTimeOffset.Now,
            ModificationDate = DateTimeOffset.Now,
            HotelId = hotelId
        };

        return role;

    }

}




