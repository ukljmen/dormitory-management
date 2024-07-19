using System.Net;

namespace DormAPI.Exceptions
{
    public class ServerErrorException : BaseAppException
    {
        public ServerErrorException(string message)
            : base(message, (int)HttpStatusCode.InternalServerError)
        {

        }
    }
}
