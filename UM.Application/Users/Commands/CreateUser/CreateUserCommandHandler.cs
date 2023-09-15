using MediatR;
using UM.Domain.Entities;
using UM.Domain.Enums;
using UM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using UM.Domain.Exceptions;
using UM.Domain.Constants;

namespace UM.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    readonly IUser _userRepository;

    public CreateUserCommandHandler(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isUserExistWithEmail = await _userRepository.GetUserByEmail(request.Email);

        if (isUserExistWithEmail != null)
            throw new UserAlreadyExistException(String.Format(ValidationMessages.User.UserAlreadyExist,request.Email));

        var user = User.CreateNewUser(request.HotelId,request.FirstName,request.LastName,request.Email,request.Username);
        await _userRepository.AddUser(user,request.Password,request.Roles);
        var createUserResponse = new CreateUserResponse(user);
        return createUserResponse;
    }
}
