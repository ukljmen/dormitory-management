using DormAPI.Models.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DormAPI.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        [MaxLength(256)]
        public string UserName { get; init; } = default!;

        [MaxLength(256)]
        public string FirstName { get; init; } = default!;

        [MaxLength(256)]
        public string LastName { get; init; } = default!;

        [MaxLength(256)]
        public string Email { get; init; } = default!;

        [MaxLength(256)]
        public string PhoneNumber { get; init; } = default!;

        [MaxLength(256)]
        public string Password { get; init; } = default!;

        public UserRole Role { get; init; }

        public string? IndexNumber { get; init; } = default!;

        public int? FloorNumber { get; init; } = default!;

        public int? RoomNumber { get; init; } = default!;
    }
}
