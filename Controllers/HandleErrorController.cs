using DormAPI.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DormAPI.Controllers
{
    public abstract class HandleErrorController<T> : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<T> _logger;

        protected HandleErrorController(ISender sender, ILogger<T> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task<IActionResult> SendRequestAsync<TResponse>(IRequest<TResponse> request)
        {
            try
            {
                return Ok(await _sender.Send(request));
            }
            catch(BaseAppException ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(ex.StatusCode, ex.Message);
            }
        }
    }
}
