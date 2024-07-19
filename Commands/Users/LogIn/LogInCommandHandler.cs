using DormAPI.Services.Users;
using MediatR;

namespace DormAPI.Commands.Users.LogIn
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LogInResponse>
    {
        private readonly IUserService _service;

        public LogInCommandHandler(IUserService service)
        {
            _service = service;
        }

        public Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            return _service.LogInAsync(request, cancellationToken);
        }
    }
}
