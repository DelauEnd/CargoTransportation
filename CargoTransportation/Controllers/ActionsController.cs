using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransportation.Controllers
{
    public class ActionsController : ExtendedControllerBase
    {
        [HttpGet]
        public IActionResult Logout()
        {
            request.UnauthorizeUser();
            return RedirectToAction("Index","Home");
        }
    }
}