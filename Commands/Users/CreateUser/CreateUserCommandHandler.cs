using DormAPI.Services.Users;
using MediatR;

namespace DormAPI.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return _userService.CreateUserAsync(request, cancellationToken);
        }
    }
}
