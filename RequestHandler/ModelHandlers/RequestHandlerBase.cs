﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RequestHandler.ModelHandlers
{
    public class RequestHandlerBase
    {
        protected IHttpClientService HttpClient { get; set; }

        public RequestHandlerBase(IHttpClientService client)
        {
            this.HttpClient = client;
        }
    }
}
