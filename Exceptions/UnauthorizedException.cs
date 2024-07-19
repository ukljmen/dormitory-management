using System.Net;

namespace DormAPI.Exceptions
{
    public class UnauthorizedException : BaseAppException
    {
        public UnauthorizedException(string message)
            : base(message, (int)HttpStatusCode.Unauthorized)
        {

        }
    }
}
