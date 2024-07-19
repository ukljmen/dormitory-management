using DormAPI.Attributes;
using DormAPI.Data;
using DormAPI.Exceptions;
using DormAPI.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminPanelController : HandleErrorController<AdminPanelController>
    {
        private readonly ApplicationDbContext _db;

        public AdminPanelController(
            ISender sender,
            ILogger<AdminPanelController> logger,
            ApplicationDbContext db)
            : base(sender, logger)
        {
            _db = db;
        }

        [HttpPost("InitDorm")]
        [Authorize]
        [CheckRole(Models.Enums.UserRole.Admin)]
        public async Task<IActionResult> InitDormAsync(int[] rooms)
        {
            if(await _db.Floors.AnyAsync())
            {
                return BadRequest("DORM_ALREADY_INITIALIZED");
            }

            if(rooms.Any(r => r < 1))
            {
                return BadRequest("INVALID_ROOMS_COUNT");
            }

            var floors = rooms
                .Select((r, i) => new Floor()
                {
                    FloorNumber = i + 1,
                    Rooms = Enumerable.Range(1, r)
                        .Select(j => new Room() { RoomNumber = (i + 1) * 10 + j })
                        .ToList()
                })
                .ToList();

            _db.AddRange(floors);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
