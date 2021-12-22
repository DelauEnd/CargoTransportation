using System.Net.Http;

namespace RequestHandler.ModelHandlers
{
    public class RequestHandlerBase
    {
        protected string BaseUrl { get; private set; }
        protected HttpClient Client { get; set; }

        public RequestHandlerBase(HttpClient client, string baseUrl)
        {
            this.BaseUrl = baseUrl;
            this.Client = client;
        }
    }
}
