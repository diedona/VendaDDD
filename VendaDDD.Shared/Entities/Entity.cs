using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Entities
{
    public abstract class Entity
    {
        protected IValidator _Validator;

        public Guid Id { get; private set; }

        public Entity(Guid? id)
        {
            Id = id ?? Guid.NewGuid();
        }

        public abstract ValidationResult Validar();
    }
}
