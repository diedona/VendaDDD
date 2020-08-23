using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedKernel.Repositories
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void RollBack();

        void Registrar(IRepository repositorio);
        TRepositorio PegarRepositorio<TRepositorio>() where TRepositorio : IRepository;

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}
