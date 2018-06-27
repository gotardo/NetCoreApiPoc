using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreApiPoc.Controllers
{
    [Route("hello-world")]
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public string Get() => "OK";
    }
}
