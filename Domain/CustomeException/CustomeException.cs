using System.Net;

namespace ProductCatalog.Domain.CustomeException
{
    public class CustomeException : Exception
    {
        public HttpStatusCode ErrorCode { get; }

        public CustomeException(string _Message, HttpStatusCode _ErrorCode) : base(_Message)
        {
            ErrorCode = _ErrorCode;
        }
    }
}
