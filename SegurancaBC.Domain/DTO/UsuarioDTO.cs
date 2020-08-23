using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}
