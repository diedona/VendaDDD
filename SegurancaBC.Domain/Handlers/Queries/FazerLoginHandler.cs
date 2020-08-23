using MediatR;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Queries;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Handlers;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SegurancaBC.Domain.Handlers.Queries
{
    public class FazerLoginHandler : BaseHandler, IRequestHandler<FazerLoginQuery, UsuarioDTO>
    {
        public FazerLoginHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<UsuarioDTO> Handle(FazerLoginQuery request, CancellationToken cancellationToken)
        {
            UsuarioAutenticacaoDTO autenticacao = await _UoW.PegarRepositorio<IUsuarioRepository>()
                .CarregarUsuario(new Email(request.NomeDeUsuario));

            return new UsuarioDTO();
        }
    }
}
