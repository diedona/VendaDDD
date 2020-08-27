using MediatR;
using SegurancaBC.Domain.DTO.Usuario;
using SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SegurancaBC.Application.UsuarioCases.FazerLogin
{
    public class FazerLoginHandler : IRequestHandler<FazerLoginQuery, UsuarioDTO>
    {
        private readonly IUnitOfWork _UoW;
        private readonly FazerLoginUseCase _FazerLoginUseCase;

        public FazerLoginHandler(IUnitOfWork uow, FazerLoginUseCase fazerLoginUseCase)
        {
            _UoW = uow;
            _FazerLoginUseCase = fazerLoginUseCase;
        }

        public async Task<UsuarioDTO> Handle(FazerLoginQuery request, CancellationToken cancellationToken)
        {
            _UoW.Begin();

            try
            {
                UsuarioDTO usuarioDTO = await _FazerLoginUseCase.Executar(request);
                _UoW.Commit();

                return usuarioDTO;
            }
            catch (Exception)
            {
                _UoW.RollBack();
                throw;
            }
        }
    }
}
