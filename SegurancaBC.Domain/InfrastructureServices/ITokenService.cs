using SegurancaBC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.InfrastructureServices
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
