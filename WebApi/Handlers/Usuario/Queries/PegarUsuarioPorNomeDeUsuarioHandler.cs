using Infrastructure.Repositories.UoW;
using MediatR;
using SegurancaBC.Domain.DTO;
using SegurancaBC.Domain.Queries;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Handlers.Usuario.Queries
{
    public class PegarUsuarioPorNomeDeUsuarioHandler : IRequestHandler<PegarUsuarioPorNomeDeUsuarioQuery, UsuarioDTO>
    {
        private readonly IUnitOfWork _UoW;

        public PegarUsuarioPorNomeDeUsuarioHandler(IUnitOfWork uow)
        {
            _UoW = uow;
        }

        public async Task<UsuarioDTO> Handle(PegarUsuarioPorNomeDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            UsuarioDTO usuario = await _UoW.UsuarioRepository.CarregarUsuario(new Email(request.NomeDeUsuario));
            return usuario;
        }
    }
}
