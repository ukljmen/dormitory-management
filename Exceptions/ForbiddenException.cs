using System.Net;

namespace DormAPI.Exceptions
{
    public class ForbiddenException : BaseAppException
    {
        public ForbiddenException(string message)
            : base(message, (int)HttpStatusCode.Forbidden)
        {
        }
    }
}
