using Microsoft.Extensions.Configuration;
using RequestHandler.ModelHandlers;
using System.Net.Http;

namespace RequestHandler
{
    public class RequestManager : IRequestManager
    {
        private HttpClient Client { get; set; }
        private readonly IConfiguration configuration;
        private string BaseUrl
            => configuration.GetSection("ApiBaseUrl").Value;

        public RequestManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            Client = new HttpClient();
        }

        private CargoRequestHandler cargoRequestHandler;
        public CargoRequestHandler CargoRequestHandler => cargoRequestHandler ??= cargoRequestHandler = new CargoRequestHandler(Client, BaseUrl);
    }
}
