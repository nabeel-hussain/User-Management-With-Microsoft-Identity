
namespace UM.Domain.Primitives;

public interface IEntity
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
}
