using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SegurancaBC.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Connection
{
    public class ConnectionData : IConnectionData
    {
        private readonly IConfiguration _Configuration;

        public ConnectionData(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string ConnectionString => _Configuration.GetConnectionString("DefaultConnection");
    }
}
