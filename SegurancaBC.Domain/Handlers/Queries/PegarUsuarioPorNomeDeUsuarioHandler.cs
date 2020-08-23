using MediatR;
using SegurancaBC.Domain.DTO;
using SegurancaBC.Domain.Queries;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace SegurancaBC.Handlers.Queries
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
            IUsuarioRepository usuarioRepository = _UoW.PegarRepositorio<IUsuarioRepository>();
            UsuarioDTO usuario = await usuarioRepository.CarregarUsuario(new Email(request.NomeDeUsuario));
            return usuario;
        }
    }
}
