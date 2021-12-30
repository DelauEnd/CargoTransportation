using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CargoTransportation.ActionFilters;
using CargoTransportation.ObjectsForUpdate;
using CargoTransportation.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CargoTransportation.Controllers
{
    [Route("Cargoes/Categories")]
    [ServiceFilter(typeof(AuthenticatedAttribute))]
    public class CargoCategoriesController : ExtendedControllerBase
    {
        [HttpGet]
        public async Task <ActionResult> Index()
        {
            var response = await request.CargoCategoriesRequestHandler.GetAllCategories();

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var category = JsonConvert.DeserializeObject<IEnumerable<CargoCategoryDto>>(await response.Content.ReadAsStringAsync());
            return View(category);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryForCreationDto category)
        {
            HttpContent content = BuildHttpContent(category);
            var response = await request.CargoCategoriesRequestHandler.CreateCategory(content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id}/Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await request.CargoRequestHandler.DeleteCargoById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await request.CargoCategoriesRequestHandler.GetAllCategories();

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var categories = JsonConvert.DeserializeObject<IEnumerable<CargoCategoryDto>>(await response.Content.ReadAsStringAsync());
            var category = categories.Where(categ => categ.Id == id).FirstOrDefault();

            var categoryToUpdate = new CargoCategoryForUpdateDto
            {
                Title = category.Title
            };

            return View(categoryToUpdate);
        }

        [HttpPost]
        [Route("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CargoCategoryForUpdateDto category)
        {
            HttpContent content = BuildHttpContent(category);
            var response = await request.CargoCategoriesRequestHandler.PutCategoryById(id, content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }
    }
}