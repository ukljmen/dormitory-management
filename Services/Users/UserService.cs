using AutoMapper;
using DormAPI.Commands.Users.CreateUser;
using DormAPI.Commands.Users.LogIn;
using DormAPI.Data;
using DormAPI.Exceptions;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DormAPI.Services.Users
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public UserService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            IConfiguration configuration,
            ApplicationDbContext db) : base(mapper, httpContextAccessor)
        {
            _userManager = userManager;
            _configuration = configuration;
            _db = db;
        }

        public async Task<LogInResponse> LogInAsync(LogInCommand command, CancellationToken ct)
        {
            var userName = command.Login;
            var password = command.Password;

            var user = await _userManager.FindByNameAsync(userName);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var userRole = (await _userManager.GetRolesAsync(user)).First();

                var authClaims = new List<Claim>
                {
                    new("Id", user.Id.ToString()),
                    new(ClaimTypes.Name, user.UserName!),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(ClaimTypes.Role, userRole)
                };

                int personId = userRole switch
                {
                    "Student" => (await _db.Students.FirstOrDefaultAsync(m => m.UserId == user.Id, ct))!.Id,
                    "Conservator" => (await _db.Conservators.FirstOrDefaultAsync(m => m.UserId == user.Id, ct))!.Id,
                    _ => (await _db.Managers.FirstOrDefaultAsync(m => m.UserId == user.Id, ct))!.Id,
                };

                authClaims.Add(new("PersonId", personId.ToString()));

                var token = GenerateToken(authClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                var role = Enum.Parse<UserRole>(userRole);

                return new LogInResponse(tokenString, role, personId, userName);
            }

            throw new BadRequestException(ErrorMessages.WrongCredentials);
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserCommand command, CancellationToken ct)
        {
            if ((await _userManager.FindByEmailAsync(command.Email)) != null)
                throw new BadRequestException(ErrorMessages.EmailTaken);
            if ((await _userManager.FindByNameAsync(command.UserName)) != null)
                throw new BadRequestException(ErrorMessages.UserNameTaken);

            if(!Enum.IsDefined(typeof(UserRole), command.Role))
            {
                throw new BadRequestException(ErrorMessages.RoleNotDefined + ": " + command.Role);
            }

            var callerRole = GetUserRoleFromToken();

            if (callerRole == UserRole.Manager && command.Role == UserRole.Admin)
            {
                throw new BadRequestException(ErrorMessages.RoleNotAllowed);
            }

            int roomId = 0;

            if (command.Role == UserRole.Student)
            {
                if (command.FloorNumber == null || command.RoomNumber == null || command.IndexNumber == null)
                {
                    throw new BadRequestException(ErrorMessages.InvalidStudentMissingValues);
                }

                roomId = await GetRoomIdAsync(command);

                if(await _db.Students.AnyAsync(s => s.IndexNumber == command.IndexNumber))
                {
                    throw new BadRequestException(ErrorMessages.IndexNumberTaken);
                }
            }

            var user = _mapper.Map<User>(command);

            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager
                .CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(
                    "\n", 
                    result.Errors
                        .Select(e => $"{e.Code}: {e.Description}")
                        .ToList()
                );

                throw new BadRequestException(message);
            }

            await _userManager.AddToRoleAsync(user, command.Role.ToString());

            Person person = command.Role switch
            {
                UserRole.Manager or UserRole.Admin => new Manager(),
                UserRole.Conservator => new Conservator(),
                _ => new Student() { RoomId = roomId, IndexNumber = command.IndexNumber! }
            };

            person.UserId = user.Id;
            person.FirstName = command.FirstName;
            person.LastName = command.LastName;
            
            _db.Add(person);
            await _db.SaveChangesAsync(ct);

            return new(person);
        }

        private async Task<int> GetRoomIdAsync(CreateUserCommand command)
        {
            var room = await _db.Floors
                .Include(f => f.Rooms)
                .Where(f => f.FloorNumber == command.FloorNumber)
                .SelectMany(f => f.Rooms)
                .SingleOrDefaultAsync(r => r.RoomNumber == command.RoomNumber)
                ?? throw new NotFoundException(typeof(Room), (int)command.RoomNumber!);

            return room.Id;
        }

        private JwtSecurityToken GenerateToken(IEnumerable<Claim> claims)
        {
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            return new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: new(authKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
