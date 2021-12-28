using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class CargoesController : ExtendedControllerBase
    {
        // GET: Cargoes
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await request.CargoRequestHandler.GetAllCargoes();

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var cargoes = JsonConvert.DeserializeObject<IEnumerable<CargoDto>>(await response.Content.ReadAsStringAsync());
            return View(cargoes);
        }

        
        [HttpGet]
        [Route("Cargoes/{id}/Details")]
        public async Task<ActionResult> Details(int id)
        {
            var response = await request.CargoRequestHandler.GetCargoById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var cargo = JsonConvert.DeserializeObject<CargoDto>(await response.Content.ReadAsStringAsync());

            return View(cargo.Dimensions);
        }

        [HttpGet]
        [Route("Orders/{orderId}/CreateCargo")]
        public ActionResult CreateCargo(int orderId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Orders/{orderId}/CreateCargo")]
        public ActionResult CreateCargo(CargoForCreationDto cargo, int orderId)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cargoes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cargoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Cargoes/{id}/Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await request.CargoRequestHandler.DeleteCargoById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction("Index");
        }
    }
}