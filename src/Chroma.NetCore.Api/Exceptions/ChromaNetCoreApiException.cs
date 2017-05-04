using System;
using System.Net;

namespace Chroma.NetCore.Api.Exceptions
{
    public class  ChromaNetCoreApiException : Exception 
    {
        public HttpStatusCode HttpStatusCode { get; }

        public ChromaNetCoreApiException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.Unused;
        }

        public ChromaNetCoreApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            HttpStatusCode = statusCode;
        }

        public ChromaNetCoreApiException(string message, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            HttpStatusCode = statusCode;
        }
    }
}
