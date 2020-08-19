using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        public Entity(Guid? id)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
