using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("Hello")]
        public ActionResult Hello([FromQuery] string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return Ok("Hello World!");
            else
                return Ok($"Hello, {name}!");
        }
    }
}
