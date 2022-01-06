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
    [Route ("Customers")]
    [ServiceFilter(typeof(AuthenticatedAttribute))]
    public class CustomersController : ExtendedControllerBase
    {
        static CustomerForUpdateDto CustomerToUpdate { get; set; }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await request.CustomerRequestHandler.GetAllCustomers();

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(await response.Content.ReadAsStringAsync());
            return View(customers);
        }

        [HttpGet]
        [Route("Create")]
        [ServiceFilter(typeof(HasManagerRole))]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(HasManagerRole))]
        public async Task<ActionResult> Create(CustomerForCreationDto customer)
        {
            HttpContent content = BuildHttpContent(customer);
            var response = await request.CustomerRequestHandler.CreateCustomer(content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id}/Delete")]
        [ServiceFilter(typeof(HasManagerRole))]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await request.CustomerRequestHandler.DeleteCustomerById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/Edit")]
        [ServiceFilter(typeof(HasManagerRole))]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await request.CustomerRequestHandler.GetCustomerById(id);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            var customer = JsonConvert.DeserializeObject<CustomerDto>(await response.Content.ReadAsStringAsync());

            CustomerToUpdate = new CustomerForUpdateDto
            {
                Address = customer.Address,
                ContactPerson = customer.ContactPerson
            };

            return View(CustomerToUpdate);
        }

        [HttpPost]
        [Route("{id}/Edit")]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(HasManagerRole))]
        public async Task<ActionResult> Edit(int id, CustomerForUpdateDto customer)
        {
            var jsonPatch = JsonPatcher.CreatePatch(CustomerToUpdate, customer);

            HttpContent content = BuildHttpContent(jsonPatch);
            var response = await request.CustomerRequestHandler.PatchCustomerById(id, content);

            if (!response.IsSuccessStatusCode)
                return UnsuccesfullStatusCode(response);

            return RedirectToAction(nameof(Index));
        }
    }
}