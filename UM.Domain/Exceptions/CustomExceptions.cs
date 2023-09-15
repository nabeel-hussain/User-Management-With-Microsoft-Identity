namespace UM.Domain.Exceptions;

public  class UserNotFoundException: DomainException
{
    public UserNotFoundException():base() { }
    public UserNotFoundException(string message):base(message) { }
    public UserNotFoundException(string message,Exception innerException):base(message,innerException) { }
}
public class PasswordChangeFailedException : DomainException
{
    public PasswordChangeFailedException() : base() { }
    public PasswordChangeFailedException(string message) : base(message) { }
    public PasswordChangeFailedException(string message, Exception innerException) : base(message, innerException) { }
}
public  class LoginFailedException : DomainException
{
    public LoginFailedException() : base() { }
    public LoginFailedException(string message) : base(message) { }
    public LoginFailedException(string message, Exception innerException) : base(message, innerException) { }
}

public class HotelNotFoundException : DomainException
{
    public HotelNotFoundException() : base() { }
    public HotelNotFoundException(string message) : base(message) { }
    public HotelNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}

public class InvalidEmailException : DomainException
{
    public InvalidEmailException() : base() { }
    public InvalidEmailException(string message) : base(message) { }
    public InvalidEmailException(string message, Exception innerException) : base(message, innerException) { }
}

public class RoleNotFoundException : DomainException
{
    public RoleNotFoundException() : base() { }
    public RoleNotFoundException(string message) : base(message) { }
    public RoleNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
public class RoleIsAssignedToUsersException : DomainException
{
    public RoleIsAssignedToUsersException() : base() { }
    public RoleIsAssignedToUsersException(string message) : base(message) { }
    public RoleIsAssignedToUsersException(string message, Exception innerException) : base(message, innerException) { }
}
public class UserAlreadyExistException : DomainException
{
    public UserAlreadyExistException() : base() { }
    public UserAlreadyExistException(string message) : base(message) { }
    public UserAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
}

public class RoleAlreadyExistException : DomainException
{
    public RoleAlreadyExistException() : base() { }
    public RoleAlreadyExistException(string message) : base(message) { }
    public RoleAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
}
