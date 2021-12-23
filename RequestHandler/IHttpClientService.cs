using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace RequestHandler
{
    public interface IHttpClientService
    {
        public HttpClient Client { get; set; }
        public HttpClientHandler Handler { get; set; }
        public CookieContainer CookieContainer { get; set; }
    }
}
