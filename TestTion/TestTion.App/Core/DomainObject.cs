using System;

namespace TestTion.App.Core
{
    public abstract class DomainObject
    {
        public Guid Id { get; set; }

        public DomainObject()
        {
            Id = Guid.NewGuid();
        }
    }
}