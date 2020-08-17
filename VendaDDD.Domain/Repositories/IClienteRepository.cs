using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Entities;

namespace VendaBC.Domain.Repositories
{
    public interface IClienteRepository
    {
        Cliente CarregarCliente(Guid id);
    }
}
