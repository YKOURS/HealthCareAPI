using System.Net;

namespace Authentication.Domain.Services
{
    public class BaseService
    {
        public class Response<T>(T? Data, string? Message, HttpStatusCode StatusCode) where T : class
        {
            public T? Data { get; set; } = Data;
            public string? Message { get; set; } = Message;
            public HttpStatusCode StatusCode { get; set; } = StatusCode;
        }
    }
}
