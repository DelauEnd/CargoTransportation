using CargoTransportation.ActionFilters;
using CargoTransportation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class AuthenticationController : ExtendedControllerBase
    {
        public ActionResult Login(string login, string password)
        {
            var user = new UserForAuthenticationDto()
            {
                Password = password,
                UserName = login
            };
            return View(user);
        }

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

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(UserForCreationDto user)
        {
            try
            {
                HttpContent content = BuildHttpContent(user);
                var response = await request.AuthenticationRequestHandler.CreateUser(content);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var responseContent = JsonSerializer.Deserialize<TokenModel>(await response.Content.ReadAsStringAsync());

                return RedirectToAction("Login", new { login = user.UserName, password = user.Password });
            }
            catch
            {
                return View();
            }
        }

        [ServiceFilter(typeof(AuthenticatedAttribute))]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(AuthenticatedAttribute))]
        public async Task<ActionResult> AddRole(UserRole userRole)
        {
            try
            {
                var response = await request.AuthenticationRequestHandler.AddRole(userRole.UserName, userRole.Role);

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var responseContent = JsonSerializer.Deserialize<TokenModel>(await response.Content.ReadAsStringAsync());

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}