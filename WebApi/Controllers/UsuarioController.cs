using System;
using System.Threading.Tasks;
using Infrastructure.Repositories.UoW;
using Microsoft.AspNetCore.Mvc;
using SegurancaBC.Domain.DTO;
using SharedKernel.ValueObjects;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{nomeDeUsuario}")]
        public async Task<ActionResult<UsuarioDTO>> Get(string nomeDeUsuario)
        {
            _UnitOfWork.Begin();
            try
            {
                UsuarioDTO usuario = await _UnitOfWork.UsuarioRepository.CarregarUsuario(new Email(nomeDeUsuario));
                _UnitOfWork.Commit();

                if (usuario == null)
                    return NotFound();
                else
                    return Ok(usuario);
            }
            catch (Exception ex)
            {
                _UnitOfWork.RollBack();
                return BadRequest(ex.Message);
            }
        }
    }
}
