namespace UM.Domain.Exceptions;

public abstract class DomainException: Exception
{
    public DomainException() : base() { }
    public DomainException(string message): base(message) { }
    public DomainException(string message, Exception innerException) : base(message,innerException) { }
}
