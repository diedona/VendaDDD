using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerCustomBase
    {
        public PingController(IMediator mediator) : base(mediator)
        {
        }

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
