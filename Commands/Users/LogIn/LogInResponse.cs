using DormAPI.Models.Enums;
using Microsoft.AspNetCore.SignalR;

namespace DormAPI.Commands.Users.LogIn
{
    public record LogInResponse(
        string Token,
        UserRole Role,
        int PersonId,
        string UserName)
    {
    }
}
