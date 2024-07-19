namespace DormAPI.Exceptions
{
    public class BaseAppException : Exception
    {
        public int StatusCode { get; init; }

        public BaseAppException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
