using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Queries;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerCustomBase
    {
        public LoginController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FazerLoginQuery model)
        {
            UsuarioDTO usuario = await _Mediator.Send(model);
            return Ok();
        }
    }
}
