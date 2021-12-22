using System.Net.Http;
using System.Threading.Tasks;

namespace RequestHandler.ModelHandlers
{
    public class CargoRequestHandler : RequestHandlerBase
    {
        private readonly string controllerUrl = "/Cargoes";

        public CargoRequestHandler(HttpClient client, string baseUrl) : base(client, baseUrl)
        {
        }

        public async Task<HttpResponseMessage> GetAllCargoes()
            => await Client.GetAsync(BaseUrl + controllerUrl);

        public async Task<HttpResponseMessage> GetAllCargoById(int cargoId)
            => await Client.GetAsync(BaseUrl + controllerUrl + $"/{cargoId}");

        public async Task<HttpResponseMessage> DeleteCargoById(int cargoId)
            => await Client.DeleteAsync(BaseUrl + controllerUrl + $"/{cargoId}");
    }
}
