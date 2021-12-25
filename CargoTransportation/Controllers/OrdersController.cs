using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CargoTransportation.Controllers
{
    public class OrdersController : ExtendedControllerBase
    {
        // GET: Orders
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await request.OrderRequestHandler.GetAllOrders();
            IEnumerable<OrderDto> orders;

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            orders = JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(await response.Content.ReadAsStringAsync());
            return View(orders);
        }

        [HttpGet]
        [Route("Orders/{id}/Cargoes")]
        public async Task<ActionResult> Cargoes(int id)
        {
            var response = await request.OrderRequestHandler.GetCargoesForOrder(id);
            IEnumerable<CargoDto> cargoes;

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            ViewBag.OrderToEdit = id;

            cargoes = JsonConvert.DeserializeObject<IEnumerable<CargoDto>>(await response.Content.ReadAsStringAsync());

            return View(cargoes);
        }

        // GET: Orders/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Orders/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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