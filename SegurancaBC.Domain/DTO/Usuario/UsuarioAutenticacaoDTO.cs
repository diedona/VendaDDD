using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.DTO.Usuario
{
    public class UsuarioAutenticacaoDTO
    {
        public Guid Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Ativo { get; set; }
    }
}
