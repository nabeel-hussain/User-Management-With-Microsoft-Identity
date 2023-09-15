
using UM.Domain.Entities;
using UM.Domain.Enums;
using MediatR;

namespace UM.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password,
    List<string> Roles,
    Guid HotelId) : IRequest<CreateUserResponse>;
