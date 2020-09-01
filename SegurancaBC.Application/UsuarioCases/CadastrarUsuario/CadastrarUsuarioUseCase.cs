using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurancaBC.Application.UsuarioCases.CadastrarUsuario
{
    public class CadastrarUsuarioUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly UsuarioDomainService _UsuarioDomainService;

        public CadastrarUsuarioUseCase(IUnitOfWork unitOfWork, UsuarioDomainService usuarioDomainService)
        {
            _UnitOfWork = unitOfWork;
            _UsuarioDomainService = usuarioDomainService;
        }

        public async Task<Usuario> Executar(CadastrarUsuarioCommand request)
        {
            Usuario novoUsuario = new Usuario(new Email(request.NomeDeUsuario));
            _UsuarioDomainService.DefinirSenha(novoUsuario, request.Password);

            if(novoUsuario.Invalid)
            {
                IEnumerable<string> notificacoes = novoUsuario.Notifications.Select(x => x.Message).ToList();
                throw new Exception(string.Join(",", notificacoes));
            }

            Guid id = await _UnitOfWork.PegarRepositorio<IUsuarioRepository>().GravarUsuario(novoUsuario);

            return novoUsuario;
        }
    }
}
