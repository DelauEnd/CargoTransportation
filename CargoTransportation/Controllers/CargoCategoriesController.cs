using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CargoTransportation.ObjectsForUpdate;
using CargoTransportation.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CargoTransportation.Controllers
{
    [Route("Cargoes/Categories")]
    public class CargoCategoriesController : ExtendedControllerBase
    {
        CargoCategoryForUpdateDto CategoryForUpdate { get; set; }

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

        // GET: CargoCategories/Delete/5
        [HttpGet]
        [Route("{id}/Delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("{id}/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

            CategoryForUpdate = new CargoCategoryForUpdateDto
            {
                Title = category.Title
            };

            return View(CategoryForUpdate);
        }

        [HttpPost]
        [Route("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CargoCategoryForUpdateDto category)
        {
            var categoryDiff = JsonPatcher.CreatePatch(CategoryForUpdate, category);



            return View();
        }
    }
}