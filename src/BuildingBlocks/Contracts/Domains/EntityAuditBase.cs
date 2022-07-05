using Contracts.Domains.Interfaces;

namespace Contracts.Domains
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IAuditable
    {
        public DateTimeOffset CreateDate { set; get; }
        public DateTimeOffset? LastModifiedDate { set; get; }
    }
}
