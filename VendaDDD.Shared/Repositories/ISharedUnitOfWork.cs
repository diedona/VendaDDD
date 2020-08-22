using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SharedKernel.Repositories
{
    public interface ISharedUnitOfWork
    {
        void Begin();
        void Commit();
        void RollBack();

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}
