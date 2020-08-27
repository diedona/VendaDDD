using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public interface ITokenData
    {
        string Secret { get; }
    }
}
