using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public interface IConnectionData
    {
        string ConnectionString { get; }
    }
}
