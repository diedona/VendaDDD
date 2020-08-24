using MediatR;
using SegurancaBC.Domain.ApplicationServices;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Queries;
using SharedKernel.Handlers;
using SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SegurancaBC.Domain.Handlers.Queries
{
    public class FazerLoginHandler : BaseHandler, IRequestHandler<FazerLoginQuery, UsuarioDTO>
    {
        private readonly UsuarioApplicationService _UsuarioApplicationService;

        public FazerLoginHandler(IUnitOfWork uow, UsuarioApplicationService usuarioApplicationService) : base(uow)
        {
            _UsuarioApplicationService = usuarioApplicationService;
        }

        public async Task<UsuarioDTO> Handle(FazerLoginQuery request, CancellationToken cancellationToken)
        {
            _UoW.Begin();

            try
            {
                var usuarioDTO = await _UsuarioApplicationService.FazerLogin(request);
                _UoW.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }

            return new UsuarioDTO();
        }
    }
}
