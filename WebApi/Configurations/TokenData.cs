using Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configurations
{
    public class TokenData : ITokenData
    {
        private readonly IConfiguration _Configuration;

        public TokenData(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string Secret => _Configuration["Token:Secret"];
    }
}
