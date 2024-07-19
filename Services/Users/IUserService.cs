using DormAPI.Commands.Users.CreateUser;
using DormAPI.Commands.Users.LogIn;
using DormAPI.Models.Entities;

namespace DormAPI.Services.Users
{
    public interface IUserService
    {
        public Task<LogInResponse> LogInAsync(LogInCommand command, CancellationToken ct);

        public Task<CreateUserResponse> CreateUserAsync(CreateUserCommand command, CancellationToken ct);
    }
}
