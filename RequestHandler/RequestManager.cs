using Microsoft.Extensions.Configuration;
using RequestHandler.ModelHandlers;
using System;
using System.Net;
using System.Net.Http;

namespace RequestHandler
{
    public class RequestManager : IRequestManager
    {
        private IHttpClientService HttpClient { get; set; }
        private readonly IConfiguration configuration;
        private string BaseUrl
            => configuration.GetSection("ApiBaseUrl").Value;

        public RequestManager(IConfiguration configuration, IHttpClientService client)
        {
            this.configuration = configuration;
            HttpClient = client;
            HttpClient.Client.BaseAddress = new Uri(BaseUrl);
        }

        private CargoRequestHandler cargoRequestHandler;
        public CargoRequestHandler CargoRequestHandler => cargoRequestHandler ??= cargoRequestHandler = new CargoRequestHandler(HttpClient);

        private AuthenticationRequestHandler authenticationRequestHandler;
        public AuthenticationRequestHandler AuthenticationRequestHandler => authenticationRequestHandler ??= authenticationRequestHandler = new AuthenticationRequestHandler(HttpClient);
    }
}
