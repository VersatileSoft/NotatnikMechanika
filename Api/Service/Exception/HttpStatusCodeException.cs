using System.Net;

namespace NotatnikMechanika.Service.Exception
{
    public class HttpStatusCodeException : WebException
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCodeException(HttpStatusCode statusCode, WebException inner) : this(statusCode, inner.ToString()) { }
    }
}
