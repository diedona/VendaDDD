using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Ativo { get; set; }
    }
}
