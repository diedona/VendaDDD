using SharedKernel.Entities;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Entities
{
    public class Usuario : Entity
    {
        public Email NomeDeUsuario { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(Email nomeDeUsuario, Guid? id = null) : base(id)
        {
            NomeDeUsuario = nomeDeUsuario;
            Ativo = false;
        }
    }
}
