using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Domain.Entities;

namespace VendaDDD.Domain.Repositories
{
    public interface IVendedorRepository
    {
        Vendedor CarregarVendedor(Guid id);
    }
}
