using System.Net.Http;

namespace AopSample.DynamicHandlers
{
    public class RequestContext : IRequestContext
    {
        public RequestContext(HttpRequestMessage request) {
            Request = request;
        }

        public HttpRequestMessage Request { get; }
    }
}