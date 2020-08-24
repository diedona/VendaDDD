using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Base
{
    public class ControllerCustomBase : ControllerBase
    {
        protected readonly IMediator _Mediator;

        public ControllerCustomBase(IMediator mediator)
        {
            _Mediator = mediator;
        }

        protected ActionResult RetornarBadRequest(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
