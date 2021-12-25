using System.Net.Http;
using System.Threading.Tasks;

namespace RequestHandler.ModelHandlers
{
    public class RouteRequestHandler : RequestHandlerBase
    {
        private readonly string controllerUrl = "/api/Routes";

        public RouteRequestHandler(IHttpClientService client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> GetAllRoutes()
            => await HttpClient.Client.GetAsync(controllerUrl);

        public async Task<HttpResponseMessage> GetRouteById(int routeId)
            => await HttpClient.Client.GetAsync(controllerUrl + $"/{routeId}");

        public async Task<HttpResponseMessage> DeleteRouteById(int routeId)
            => await HttpClient.Client.DeleteAsync(controllerUrl + $"/{routeId}");

        public async Task<HttpResponseMessage> PutRouteById(int routeId, HttpContent content)
            => await HttpClient.Client.PatchAsync(controllerUrl + $"/{routeId}", content);

        public async Task<HttpResponseMessage> CreateRoute(HttpContent content)
               => await HttpClient.Client.PostAsync(controllerUrl, content);

        public async Task<HttpResponseMessage> MarkCargoToRoute(int routeId, HttpContent content)
              => await HttpClient.Client.PostAsync(controllerUrl + $"/{routeId}/Cargoes", content);

        public async Task<HttpResponseMessage> GetCargoesForRoute(int routeId)
               => await HttpClient.Client.GetAsync(controllerUrl + $"/{routeId}/Cargoes");
    }
}
