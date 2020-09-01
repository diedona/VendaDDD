using MediatR;
using SegurancaBC.Domain.Entities;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SegurancaBC.Application.UsuarioCases.CadastrarUsuario
{
    public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Guid>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly CadastrarUsuarioUseCase _CadastrarUsuarioUseCase;

        public CadastrarUsuarioHandler(IUnitOfWork unitOfWork, CadastrarUsuarioUseCase cadastrarUsuarioUseCase)
        {
            _UnitOfWork = unitOfWork;
            _CadastrarUsuarioUseCase = cadastrarUsuarioUseCase;
        }

        public async Task<Guid> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            _UnitOfWork.Begin();

            try
            {
                Usuario usuario = await _CadastrarUsuarioUseCase.Executar(request);
                _UnitOfWork.Commit();

                return usuario.Id;
            }
            catch (Exception)
            {
                _UnitOfWork.RollBack();
                throw;
            }
        }
    }
}
