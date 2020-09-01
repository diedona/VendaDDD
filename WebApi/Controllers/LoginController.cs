using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SegurancaBC.Application.UsuarioCases.CadastrarUsuario;
using SegurancaBC.Application.UsuarioCases.FazerLogin;
using SegurancaBC.Domain.DTO.Usuario;
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
            try
            {
                UsuarioDTO usuario = await _Mediator.Send(model);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return RetornarBadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok($"Olá {User.Identity.Name}");
        }

        [Authorize]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Guid>> CadastrarUsuario([FromBody] CadastrarUsuarioCommand command)
        {
            try
            {
                Guid id = await _Mediator.Send(command);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return RetornarBadRequest(ex);
            }
        }
    }
}
