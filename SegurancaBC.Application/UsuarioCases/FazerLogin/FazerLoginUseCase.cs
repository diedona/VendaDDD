using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Threading.Tasks;

namespace SegurancaBC.Application.UsuarioCases.FazerLogin
{
    public class FazerLoginUseCase
    {
        private readonly IUnitOfWork _UoW;
        private readonly UsuarioDomainService _UsuarioDomainService;

        public FazerLoginUseCase(IUnitOfWork uoW, UsuarioDomainService usuarioDomainService)
        {
            _UoW = uoW;
            _UsuarioDomainService = usuarioDomainService;
        }

        public async Task<UsuarioDTO> Executar(FazerLoginQuery query)
        {
            UsuarioAutenticacaoDTO autenticacao = await _UoW.PegarRepositorio<IUsuarioRepository>()
                .CarregarUsuario(new Email(query.NomeDeUsuario));

            if (autenticacao == null)
                throw new Exception("Usuário não encontrado");

            Usuario usuario = new Usuario(new Email(autenticacao.NomeDeUsuario), autenticacao.Ativo, autenticacao.Id);
            usuario.DefinirSenha(autenticacao.Salt, autenticacao.Password);

            if (!_UsuarioDomainService.CompararSenha(usuario, query.Senha))
                throw new Exception("Usuário não encontrado");

            if(!usuario.Ativo)
                throw new Exception("Usuário inativo!");

            return new UsuarioDTO()
            {
                NomeDeUsuario = usuario.NomeDeUsuario.Endereco,
                AccessToken = _UsuarioDomainService.GerarToken(usuario)
            };
        }
    }
}
