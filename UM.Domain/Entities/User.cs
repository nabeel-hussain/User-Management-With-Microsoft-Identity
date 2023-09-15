using UM.Domain.Enums;
using UM.Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace UM.Domain.Entities;

public sealed class User : IdentityUser<Guid>,IEntity,IDeletable
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid HotelId { get; set; }
    public UserStatus Status { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public DateTimeOffset? Deleted { get; set; } 

    public User() { }
    private User(Guid id, Guid hotelId, string firstName, string lastName, UserStatus status,  string email,string userName)
    {
        Id = id;
        HotelId = hotelId;
        FirstName = firstName;
        LastName = lastName;
        Status = status;
        Email = email;
        UserName= userName;
        Deleted = null;
    }

    public static User CreateNewUser(Guid hotelId, string firstName, string lastName,string email,string userName)
    {
        var status = UserStatus.Active;
        var user = new User(Guid.NewGuid(), hotelId, firstName, lastName, status,email,userName);
        return user;
    }
    public void Update(string firstName, string lastName,string email,string userName)
    {
        Email= email;
        UserName= userName;
        FirstName = firstName;
        LastName = lastName;
    }

    public void MarkAsDeleted()
    {
        Deleted = DateTimeOffset.Now;
    }
}
