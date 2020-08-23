using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Entities;

namespace VendaBC.Domain.Repositories
{
    public interface IClienteRepository : IRepository
    {
        Cliente CarregarCliente(Guid id);
    }
}
