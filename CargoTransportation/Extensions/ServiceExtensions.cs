﻿using Microsoft.Extensions.DependencyInjection;
using RequestHandler;

namespace CargoTransportation.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRequestManager(this IServiceCollection services)
            => services.AddSingleton<IRequestManager, RequestManager>();

        public static void ConfigureHttpClientServiceManager(this IServiceCollection services)
            => services.AddSingleton<IHttpClientService, HttpClientService>();
    }
}
