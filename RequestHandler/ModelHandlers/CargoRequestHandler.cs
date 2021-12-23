using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestHandler.ModelHandlers
{
    public class CargoRequestHandler : RequestHandlerBase
    {
        private readonly string controllerUrl = "/api/Cargoes";

        public CargoRequestHandler(IHttpClientService client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> GetAllCargoes()
            => await HttpClient.Client.GetAsync(controllerUrl);

        public async Task<HttpResponseMessage> GetAllCargoById(int cargoId)
            => await HttpClient.Client.GetAsync(HttpClient.Client.BaseAddress + controllerUrl + $"/{cargoId}");

        public async Task<HttpResponseMessage> DeleteCargoById(int cargoId)
            => await HttpClient.Client.DeleteAsync(HttpClient.Client.BaseAddress + $"/{cargoId}");
    }
}
