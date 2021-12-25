using Microsoft.Extensions.Configuration;
using RequestHandler.ModelHandlers;
using System;

namespace RequestHandler
{
    public class RequestManager : IRequestManager
    {
        public IHttpClientService HttpClient { get; private set; }
        private readonly IConfiguration configuration;
        private string BaseUrl
            => configuration.GetSection("ApiBaseUrl").Value;

        public RequestManager(IConfiguration configuration, IHttpClientService client)
        {
            this.configuration = configuration;
            HttpClient = client;
            HttpClient.Client.BaseAddress = new Uri(BaseUrl);
        }

        public void SetUnauthenticated()        
            => HttpClient.Authenticated = false;      

        public void RemoveToken()
        {
            SetUnauthenticated();
            HttpClient.Client.DefaultRequestHeaders.Authorization = null;
        }

        private CargoRequestHandler cargoRequestHandler;
        public CargoRequestHandler CargoRequestHandler => cargoRequestHandler ??= cargoRequestHandler = new CargoRequestHandler(HttpClient);

        private AuthenticationRequestHandler authenticationRequestHandler;
        public AuthenticationRequestHandler AuthenticationRequestHandler => authenticationRequestHandler ??= authenticationRequestHandler = new AuthenticationRequestHandler(HttpClient);
    }
}
