using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects
{
    public abstract class ValueObject
    {
        protected IValidator _Validator;

        public abstract ValidationResult Validar();
    }
}
