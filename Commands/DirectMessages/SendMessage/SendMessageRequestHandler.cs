using DormAPI.Models.Dto;
using DormAPI.Services.DirectMessages;
using MediatR;

namespace DormAPI.Commands.DirectMessages.SendMessage
{
    public class SendMessageRequestHandler
        : IRequestHandler<SendMessageRequest, DirectMessageDto>
    {
        private readonly IDirectMessagesService _service;

        public SendMessageRequestHandler(IDirectMessagesService service)
        {
            _service = service;
        }

        public Task<DirectMessageDto> Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            return _service.SendMessageAsync(request, cancellationToken);
        }
    }
}
