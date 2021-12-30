using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CargoTransportation.ActionFilters;
using CargoTransportation.ObjectsForUpdate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CargoTransportation.Controllers
{
    [Route("Routes")]
    [ServiceFilter(typeof(AuthenticatedAttribute))]   
    public class RoutesController : ExtendedControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await request.RouteRequestHandler.GetAllRoutes();

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var routes = JsonConvert.DeserializeObject<IEnumerable<RouteDto>>(await response.Content.ReadAsStringAsync());
            return View(routes);
        }

        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            var transportResponse = await request.TransportRequestHandler.GetAllTransport();

            if (!transportResponse.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(transportResponse);
   
              var transport = JsonConvert.DeserializeObject<IEnumerable<TransportDto>>(await transportResponse.Content.ReadAsStringAsync());

            ViewBag.transport = transport;

            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RouteForCreationDto route)
        {
            HttpContent content = BuildHttpContent(route);
            var response = await request.RouteRequestHandler.CreateRoute(content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id}/Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await request.RouteRequestHandler.DeleteRouteById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await request.RouteRequestHandler.GetRouteById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var route = JsonConvert.DeserializeObject<RouteDto>(await response.Content.ReadAsStringAsync());

            var transportResponse = await request.TransportRequestHandler.GetAllTransport();
            var transport = JsonConvert.DeserializeObject<IEnumerable<TransportDto>>(await transportResponse.Content.ReadAsStringAsync());

            ViewBag.transport = transport;

            var routeToUpdate = new RouteForUpdateDto
            {
                 TransportRegistrationNumber = route.TransportRegistrationNumber
            };

            return View(routeToUpdate);
        }

        [HttpPost]
        [Route("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RouteForUpdateDto route)
        {
            HttpContent content = BuildHttpContent(route);
            var response = await request.RouteRequestHandler.PutRouteById(id, content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }
    }
}