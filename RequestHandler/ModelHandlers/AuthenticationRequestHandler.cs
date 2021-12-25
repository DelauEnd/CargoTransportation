using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RequestHandler.ModelHandlers
{
    public class AuthenticationRequestHandler : RequestHandlerBase
    {
        private readonly string controllerUrl = "/api/Authentication";

        public AuthenticationRequestHandler(IHttpClientService client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> CreateUser(HttpContent content)
            => await HttpClient.Client.PostAsync(controllerUrl, content);

        public async Task<HttpResponseMessage> AuthenticateUser(HttpContent content)
            => await HttpClient.Client.PostAsync(controllerUrl + "/login", content);

        public void AddJwtTokenToHeader(string token)
        {
            HttpClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient.Authenticated = true;
        }
    }
}
