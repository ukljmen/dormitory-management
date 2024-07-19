using DormAPI.Models.Dto;
using DormAPI.Services.DirectMessages;
using MediatR;

namespace DormAPI.Commands.DirectMessages.UpdateMessage
{
    public class UpdateMessageRequestHandler : IRequestHandler<UpdateMessageRequest, DirectMessageDto>
    {
        private readonly IDirectMessagesService _service;

        public UpdateMessageRequestHandler(IDirectMessagesService service)
        {
            _service = service;
        }

        public Task<DirectMessageDto> Handle(UpdateMessageRequest request, CancellationToken cancellationToken)
        {
            return _service.UpdateMessageAsync(request, cancellationToken);
        }
    }
}
