using System.Collections.Generic;

namespace Salon.CustomerBase.Core.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity<TId>
    {
      //  public int Id { get; set; }
        public virtual TId Id { get; protected set; }

        protected BaseEntity(TId id)
        {
            Id = id;
        }

        // EF requires an empty constructor
        protected BaseEntity()
        {
        }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}