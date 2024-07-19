using DormAPI.Attributes;
using DormAPI.Commands.Rooms.AddItem;
using DormAPI.Commands.Rooms.DeleteItem;
using DormAPI.Commands.Rooms.UpdateItem;
using DormAPI.Models.Dto;
using DormAPI.Queries.GetFloors;
using DormAPI.Queries.GetRoom;
using DormAPI.Queries.GetRoomByStudentId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : HandleErrorController<RoomsController>
    {
        public RoomsController(ISender sender, ILogger<RoomsController> logger) : base(sender, logger)
        {
        }

        [HttpGet("Floors")]
        [ProducesResponseType<FloorDto[]>(200)]
        public async Task<IActionResult> GetFloorsAsync(CancellationToken ct)
        {
            return await SendRequestAsync(new GetFloorsQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType<RoomDto>(200)]
        public async Task<IActionResult> GetRoomAsync(int id)
        {
            return await SendRequestAsync(new GetRoomQuery(id));
        }

        [HttpGet("GetRoomByStudentId/{studentId}")]
        [ProducesResponseType<RoomDto>(200)]
        public async Task<IActionResult> GetRoomByStudentIdAsync(int studentId)
        {
            return await SendRequestAsync(new GetRoomByStudentIdQuery(studentId));
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItemAsync(AddItemRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPut("UpdateItem")]
        public async Task<IActionResult> UpdateItemAsync(UpdateItemRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpDelete("DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItemAsync(int itemId)
        {
            return await SendRequestAsync(new DeleteItemRequest(itemId));
        }
    }
}
