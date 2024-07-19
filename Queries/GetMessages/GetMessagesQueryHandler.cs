using DormAPI.Models.Dto;
using DormAPI.Services.DirectMessages;
using MediatR;
using System.Collections.Generic;

namespace DormAPI.Queries.GetMessages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IEnumerable<DirectMessageDto>>
    {
        private readonly IDirectMessagesService _service;

        public GetMessagesQueryHandler(IDirectMessagesService service)
        {
            _service = service;
        }

        public Task<IEnumerable<DirectMessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return _service.GetMessagesAsync(cancellationToken);
        }
    }
}
