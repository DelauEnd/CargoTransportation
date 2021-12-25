namespace RequestHandler.ModelHandlers
{
    public class RequestHandlerBase
    {
        protected IHttpClientService HttpClient { get; set; }

        public RequestHandlerBase(IHttpClientService client)
        {
            this.HttpClient = client;
        }
    }
}
