using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Application.UsuarioCases.CadastrarUsuario
{
    public class CadastrarUsuarioCommand : IRequest<Guid>
    {
        public string NomeDeUsuario { get; set; }
        public string Password { get; set; }
    }
}
