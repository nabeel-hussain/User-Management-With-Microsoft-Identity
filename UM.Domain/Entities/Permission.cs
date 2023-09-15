using System.ComponentModel.DataAnnotations.Schema;

namespace UM.Domain.Entities;

public class Permission
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public int Id { get; init; }
    public string Name { get; init; }

}
