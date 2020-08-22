using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Services
{
    public interface IHashService
    {
        (string salt, string hash) GerarHash(string texto);
        bool ValidarHash(string hashOriginal, string salt, string texto);
    }
}
