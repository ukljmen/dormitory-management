using DormAPI.Attributes;
using DormAPI.Commands.DirectMessages.DeleteMessage;
using DormAPI.Commands.DirectMessages.SendMessage;
using DormAPI.Commands.DirectMessages.UpdateMessage;
using DormAPI.Models.Dto;
using DormAPI.Queries.GetMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectMessagesController : HandleErrorController<DirectMessagesController>
    {
        public DirectMessagesController(ISender sender, ILogger<DirectMessagesController> logger)
            : base(sender, logger)
        {
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(DirectMessageDto[]), 200)]
        public async Task<IActionResult> GetMessagesByUser()
        {
            return await SendRequestAsync(new GetMessagesQuery());
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPost]
        [ProducesResponseType(typeof(DirectMessageDto), 200)]
        public async Task<IActionResult> SendMessageAsync(SendMessageRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPut]
        [ProducesResponseType(typeof(DirectMessageDto), 200)]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpDelete("{messageId}")]
        [ProducesResponseType(typeof(DirectMessageDto), 200)]
        public async Task<IActionResult> DeleteMessageAsync(int messageId)
        {
            return await SendRequestAsync(new DeleteMessageRequest(messageId));
        }
    }
}
