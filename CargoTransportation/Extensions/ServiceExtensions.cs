using Microsoft.Extensions.DependencyInjection;
using RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRequestManager(this IServiceCollection services)
            => services.AddSingleton<IRequestManager, RequestManager>();
    }
}
