using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract()
                .IsEmail(Endereco, nameof(Endereco), "Email inválido")
                .HasMinLen(Endereco, 5, nameof(Endereco), "Email muito curto")
            );
        }
    }
}
