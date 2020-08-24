using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Queries;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SegurancaBC.Domain.ApplicationServices
{
    public class UsuarioApplicationService
    {
        private readonly IUnitOfWork _UoW;
        private readonly UsuarioDomainService _UsuarioDomainService;

        public UsuarioApplicationService(IUnitOfWork uow, UsuarioDomainService usuarioDomainService)
        {
            _UoW = uow;
            _UsuarioDomainService = usuarioDomainService;
        }

        public async Task<UsuarioDTO> FazerLogin(FazerLoginQuery request)
        {
            UsuarioAutenticacaoDTO autenticacao = await _UoW.PegarRepositorio<IUsuarioRepository>()
                .CarregarUsuario(new Email(request.NomeDeUsuario));

            if (autenticacao == null)
                throw new Exception("Usuário não encontrado");

            Usuario usuario = new Usuario(new Email(autenticacao.NomeDeUsuario), autenticacao.Id);
            usuario.DefinirSenha(autenticacao.Salt, autenticacao.Password);

            if (!_UsuarioDomainService.CompararSenha(usuario, request.Senha))
                throw new Exception("Usuário não encontrado");

            return new UsuarioDTO();
        }
    }
}
