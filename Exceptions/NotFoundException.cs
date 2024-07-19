using System.Net;

namespace DormAPI.Exceptions
{
    public class NotFoundException : BaseAppException
    {
        public NotFoundException()
            : base("NOT_FOUND", (int)HttpStatusCode.NotFound)
        {
        }
        public NotFoundException(Type type, int id)
            : base($"{type}:{id} NOT_FOUND", (int)HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string message)
            : base(message, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
