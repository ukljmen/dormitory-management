using DormAPI.Models.Dto;
using DormAPI.Services.DirectMessages;
using MediatR;

namespace DormAPI.Commands.DirectMessages.DeleteMessage
{
    public class DeleteMessageRequestHandler : IRequestHandler<DeleteMessageRequest, DirectMessageDto>
    {
        private readonly IDirectMessagesService _service;

        public DeleteMessageRequestHandler(IDirectMessagesService service)
        {
            _service = service;
        }

        public Task<DirectMessageDto> Handle(DeleteMessageRequest request, CancellationToken cancellationToken)
        {
            return _service.DeleteMessageAsync(request.MessageId, cancellationToken);
        }
    }
}
