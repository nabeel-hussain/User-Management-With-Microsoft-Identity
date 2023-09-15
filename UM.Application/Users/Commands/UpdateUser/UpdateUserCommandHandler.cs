using UM.Domain.Interfaces;
using UM.Domain.SlimEntities;
using MediatR;
namespace UM.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
{
    readonly IUser _userRepository;
    public UpdateUserCommandHandler(IUser userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id);
        user.Update(request.FirstName, request.LastName, request.Email, request.UserName);
        await _userRepository.UpdateUser(user, request.Roles);
        var slimUser = new SlimUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.Email,
            Username = request.Email,
            Id = request.Id,
            HotelId = user.HotelId,
            Roles = request.Roles,
        };
        return new UpdateUserCommandResponse { user = slimUser };

    }
}
