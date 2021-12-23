using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace RequestHandler
{
    public class HttpClientService : IHttpClientService
    {
        public HttpClient Client { get; set; }
        public HttpClientHandler Handler { get; set; }
        public CookieContainer CookieContainer { get; set; }

        public HttpClientService()
        {
            Handler = new HttpClientHandler()
            {
                CookieContainer = new CookieContainer()
            };
            Client = new HttpClient(Handler);
        }
    }
}
