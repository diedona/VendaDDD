using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SegurancaBC.Domain.DTO;
using SegurancaBC.Domain.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public UsuarioController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioDTO>> Get([FromQuery]PegarUsuarioPorNomeDeUsuarioQuery nomeDeUsuarioQuery)
        {
            try
            {
                UsuarioDTO usuario = await _Mediator.Send(nomeDeUsuarioQuery);
                if (usuario == null)
                    return NotFound("Usuário não encontrado");
                else
                    return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
