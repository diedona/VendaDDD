using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.UoW
{
    public interface IUnitOfWork : ISharedUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
    }
}
