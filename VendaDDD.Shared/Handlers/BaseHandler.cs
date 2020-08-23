using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Handlers
{
    public abstract class BaseHandler
    {
        protected readonly IUnitOfWork _UoW;

        protected BaseHandler(IUnitOfWork uow)
        {
            _UoW = uow;
        }
    }
}
