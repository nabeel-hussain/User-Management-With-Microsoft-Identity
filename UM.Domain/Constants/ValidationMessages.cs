

namespace UM.Domain.Constants;

public static class ValidationMessages
{
    public static class User
    {
        public const string InvalidEmail = "The email is invalid,Please provide valid Email.";
        public const string InvalidPassword = "Please provide the password with at least one Upper Case";
        public const string LoginFailed  = "Login Failed. Either Username or Password is incorrect.";
        public const string LoginSuccess  = "User has been successfully logged";
        public const string LogoutFailed  = "Logout has been failed. ";
        public const string UserNotFound  = "User has not found, Please try again. ";
        public const string UserAlreadyExist  = "User already exist with the Email.";
        public const string PasswordChangeFailed = "Password could not be updated.";
    }
    public static class Role
    {
        public const string RoleNotFound = "Role has not found.";
        public const string RoleAlreadyExist = "Role already exist with the Name.";
        public const string RoleIsAssignedToUsers = "Role is assigned to users and hence cannot be removed.";
    }
}
