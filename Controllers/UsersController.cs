using DormAPI.Attributes;
using DormAPI.Commands.Users.CreateUser;
using DormAPI.Commands.Users.LogIn;
using DormAPI.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : HandleErrorController<UsersController>
{
    public UsersController(ISender sender, ILogger<UsersController> logger)
        : base(sender, logger)
    {
    }

    /// <summary>
    /// Sign into application
    /// </summary>
    /// <param name="command"></param>
    [HttpPost("Login")]
    [Produces(typeof(LogInResponse))]
    public async Task<IActionResult> LogInAsync([FromBody] LogInCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Adds new user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [Authorize]
    [CheckRole(UserRole.Admin, UserRole.Manager)]
    [HttpPost("CreateUser")]
    [Produces(typeof(CreateUserResponse))]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        return await SendRequestAsync(command);
    }
}