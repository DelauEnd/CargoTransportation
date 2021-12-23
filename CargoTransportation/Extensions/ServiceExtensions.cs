using Microsoft.Extensions.DependencyInjection;
using CargoTransportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
