using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects.Documentos
{
    public class RG : Documento
    {
        public RG(string numero) : base(numero, null)
        {
        }

        public override ValidationResult EstaValido() => _Validator.Validate(new ValidationContext<RG>(this));
    }
}
