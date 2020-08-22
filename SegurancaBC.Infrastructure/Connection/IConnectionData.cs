using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Infrastructure.Connection
{
    public interface IConnectionData
    {
        string ConnectionString { get; }
    }
}
