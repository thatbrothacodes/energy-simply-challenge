using Microsoft.AspNetCore.Mvc;
using server.data;
using server.data.models;
using server.services;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;

        [HttpGet]
        public async Task<ActionResult> Index(int page = 0, int pageSize = 50)
        {
            return View(await this._service.getCustomers(page, pageSize));
        }

        [HttpGet]
        public async Task<ActionResult> Add() {
            var vm = new CustomerViewModel();
            vm.Plans = await _service.getPlans();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CustomerViewModel customer) {
            if (ModelState.IsValid)
            {
                try
                {
                   await this._service.addCustomer(customer);
                }
                catch
                {
                    return RedirectToAction("Errors", new { statusCode = 500 });
                }
                
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public CustomersController(ICustomerService service) {
            this._service = service;
        }
    }
}
