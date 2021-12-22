using System.Net.Http;

namespace RequestHandler.ModelHandlers
{
    public class RequestHandlerBase
    {
        protected HttpClient Client { get; set; }

        public RequestHandlerBase(HttpClient client)
        {
            this.Client = client;
        }
    }
}
