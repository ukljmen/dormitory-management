using MediatR;

namespace DormAPI.Commands.Users.LogIn
{
    public record LogInCommand : IRequest<LogInResponse> 
    {
        public string Login { get; init; } = default!;
        public string Password { get; init; } = default!;
    }
}
