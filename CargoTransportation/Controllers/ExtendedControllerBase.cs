using Microsoft.AspNetCore.Mvc;
using RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CargoTransportation.Controllers
{
    public class ExtendedControllerBase : Controller
    {
        private IRequestManager _request;
        protected IRequestManager request => _request ??= HttpContext.RequestServices.GetService<IRequestManager>();

        protected static StringContent BuildHttpContent(object user)
            => new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
    }
}
