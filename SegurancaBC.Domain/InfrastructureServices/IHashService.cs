using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.InfrastructureServices
{
    public interface IHashService
    {
        (string salt, string hash) GerarHash(string texto);
        bool ValidarHash(string hashOriginal, string salt, string texto);
    }
}
