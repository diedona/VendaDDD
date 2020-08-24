using MediatR;
using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Queries;
using SegurancaBC.Domain.Repositories;
using SegurancaBC.Domain.Services;
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
        private readonly UsuarioService _UsuarioService;

        public FazerLoginHandler(IUnitOfWork uow, UsuarioService usuarioService) : base(uow)
        {
            _UsuarioService = usuarioService;
        }

        public async Task<UsuarioDTO> Handle(FazerLoginQuery request, CancellationToken cancellationToken)
        {
            UsuarioAutenticacaoDTO autenticacao = await _UoW.PegarRepositorio<IUsuarioRepository>()
                .CarregarUsuario(new Email(request.NomeDeUsuario));

            if (autenticacao == null)
                throw new Exception("Usuário não encontrado");

            Usuario usuario = new Usuario(new Email(autenticacao.NomeDeUsuario), autenticacao.Id);
            usuario.DefinirSenha(autenticacao.Salt, autenticacao.Password);

            if (!_UsuarioService.CompararSenha(usuario, request.Senha))
                throw new Exception("Usuário não encontrado");

            return new UsuarioDTO();
        }
    }
}
