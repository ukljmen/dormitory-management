using System.Net;

namespace DormAPI.Exceptions
{
    public class BadRequestException : BaseAppException
    {
        public BadRequestException(string message)
            : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
