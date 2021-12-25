using RequestHandler.ModelHandlers;

namespace RequestHandler
{
    public interface IRequestManager
    {
        public IHttpClientService HttpClient { get; }
        public CargoRequestHandler CargoRequestHandler { get; }
        public AuthenticationRequestHandler AuthenticationRequestHandler { get; }
        public void SetUnauthenticated();
        public void RemoveToken();
    }
}
