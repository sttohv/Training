using Training.Core;

namespace Training.Domain.Common
{
    public abstract class NamedEntity<TData> : BaseEntity<TData>
        where TData : class, INamedEntityData, new()
    {
        protected NamedEntity() : this(null) { }
        protected NamedEntity(TData d) : base(d) { }
        public string Name => Data?.Name ?? string.Empty;
    }
}
