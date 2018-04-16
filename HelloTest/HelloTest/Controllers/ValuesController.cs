using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HelloTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<Service> _service;

        public ValuesController(IOptions<Service> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(_service.Value.Url);
                return Ok(string.Format("Url-{0}, Result-{1}", _service.Value.Url, result));
            }
        }
    }
}
