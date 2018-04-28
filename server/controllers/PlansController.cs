using Microsoft.AspNetCore.Mvc;
using server.data.models;
using server.services;
using System.Collections.Generic;
using System.Text.Encodings.Web;

using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class PlansController : Controller
    {
        private readonly IPlanService _service;

        [HttpGet]
        public async Task<ActionResult> Index(int page = 0, int pageSize = 50)
        {
            return View(await this._service.getPlans(page, pageSize));
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Plan plan) {
            if (ModelState.IsValid)
            {
                try
                {
                   await this._service.addPlan(plan);
                }
                catch
                {
                    return NotFound();
                }
                
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        public PlansController(IPlanService service) {
            this._service = service;
        }
    }
}
