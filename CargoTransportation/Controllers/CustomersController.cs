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
    [Route ("Customers")]
    [ServiceFilter(typeof(AuthenticatedAttribute))]
    public class CustomersController : ExtendedControllerBase
    {
        CustomerForUpdateDto CustomerToUpdate { get; set; }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
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
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id}/Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            

            return View();
        }

        [HttpPost]
        [Route("{id}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CargoCategoryForUpdateDto category)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}