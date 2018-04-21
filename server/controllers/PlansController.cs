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

        public async Task<List<Plan>> Index(int page = 0, int pageSize = 50)
        {
            return await this._service.getPlans(page, pageSize);
        }

        public PlansController(IPlanService service) {
            this._service = service;
        }
    }
}
