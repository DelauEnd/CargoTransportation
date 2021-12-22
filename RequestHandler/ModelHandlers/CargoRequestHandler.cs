using System.Net.Http;
using System.Threading.Tasks;

namespace RequestHandler.ModelHandlers
{
    public class CargoRequestHandler : RequestHandlerBase
    {
        private readonly string controllerUrl = "/Cargoes";

        public CargoRequestHandler(HttpClient client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> GetAllCargoes()
            => await Client.GetAsync(controllerUrl);

        public async Task<HttpResponseMessage> GetAllCargoById(int cargoId)
            => await Client.GetAsync(controllerUrl + $"/{cargoId}");

        public async Task<HttpResponseMessage> DeleteCargoById(int cargoId)
            => await Client.DeleteAsync(controllerUrl + $"/{cargoId}");
    }
}
