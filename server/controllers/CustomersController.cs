using Microsoft.AspNetCore.Mvc;
using server.data;
using server.data.models;
using server.services;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using System.Linq;

namespace server.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;

        public async Task<List<Customer>> Index(int page = 0, int pageSize = 50)
        {
            return await this._service.getCustomers(page, pageSize);
        }

        public CustomersController(ICustomerService service) {
            this._service = service;
        }
    }
}
