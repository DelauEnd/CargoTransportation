﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
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
            IEnumerable<CargoDto> cargoes;

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            cargoes = JsonSerializer.Deserialize<IEnumerable<CargoDto>>(await response.Content.ReadAsStringAsync());
            return View(cargoes);
        }

        // GET: Cargoes/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("Orders/{id}/CreateCargo")]
        public ActionResult CreateCargo(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Orders/{id}/CreateCargo")]
        public ActionResult CreateCargo(CargoForCreationDto cargo, int id)
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

        // GET: Cargo/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cargo/Delete/5
        [HttpPost]
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
    }
}