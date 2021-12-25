using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransportation.Controllers
{
    public class ActionsController : ExtendedControllerBase
    {
        public IActionResult Logout()
        {
            request.RemoveToken();
            return RedirectToAction("Index","Home");
        }
    }
}