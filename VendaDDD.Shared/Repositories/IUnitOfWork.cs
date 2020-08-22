using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Repositories
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}
