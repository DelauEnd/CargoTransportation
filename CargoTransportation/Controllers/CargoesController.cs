using CargoTransportation.ObjectsForUpdate;
using CargoTransportation.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CargoTransportation.Controllers
{
    public class CargoesController : ExtendedControllerBase
    {
        static CargoForUpdateDto CargoToUpdate { get; set; }

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
        public async Task<ActionResult> CreateCargo(int orderId)
        {
            var categoriesResponse = await request.CargoCategoriesRequestHandler.GetAllCategories();

            if (!categoriesResponse.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(categoriesResponse);

            var categories = JsonConvert.DeserializeObject<IEnumerable<CargoCategoryDto>>(await categoriesResponse.Content.ReadAsStringAsync());

            ViewBag.categories = categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Orders/{orderId}/CreateCargo")]
        public async Task<ActionResult> CreateCargo(CargoForCreationDto cargo, int orderId)
        {
            var cargoToAdd = new List<CargoForCreationDto>() { cargo };

            HttpContent content = BuildHttpContent(cargoToAdd);
            var response = await request.OrderRequestHandler.CreateCargoForOrder(orderId, content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Cargoes/{id}/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await request.CargoRequestHandler.GetCargoById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var cargo = JsonConvert.DeserializeObject<CargoDto>(await response.Content.ReadAsStringAsync());

            var categoriesResponse = await request.CargoCategoriesRequestHandler.GetAllCategories();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CargoCategoryDto>>(await categoriesResponse.Content.ReadAsStringAsync());

            ViewBag.categories = categories;


            CargoToUpdate = new CargoForUpdateDto
            {
                Title = cargo.Title,
                ArrivalDate = cargo.ArrivalDate,
                DepartureDate = cargo.DepartureDate,
                CategoryId = categories.Where(categ => categ.Title == cargo.Category).FirstOrDefault().Id,
                Weight = cargo.Weight,
                Dimensions = cargo.Dimensions,                
            };

            return View(CargoToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Cargoes/{id}/Edit")]
        public async Task<ActionResult> Edit(int id, CargoForUpdateDto cargo)
        {
            var jsonPatch = JsonPatcher.CreatePatch(CargoToUpdate, cargo);

            HttpContent content = BuildHttpContent(jsonPatch);
            var response = await request.CargoRequestHandler.PatchCargoById(id, content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
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