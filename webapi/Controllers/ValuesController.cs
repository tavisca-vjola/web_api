using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello world";
        }

        // GET api/values/5
        [HttpGet("{message}")]
        public ActionResult<string> Get(string message)
        {
            return message == "Hello" ? "Hi" : "Hello";
        }

       

      
    }
}
