using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransportation.Controllers
{
    public class AuthenticationController : ExtendedControllerBase
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authentication/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Authentication/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserForAuthenticationDto user)
        {
            try
            {
                HttpContent content = BuildHttpContent(user);
                var response = await request.AuthenticationRequestHandler.AuthenticateUser(content);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var responseContent = JsonSerializer.Deserialize<TokenModel>(await response.Content.ReadAsStringAsync());

                request.AuthenticationRequestHandler.AddJwtTokenToHeader(responseContent.Token);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View();
            }
        }

             

        // GET: Authentication/Registration
        public ActionResult Registration()
        {
            return View();
        }

        // POST: Authentication/Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserForCreationDto user)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}