using System;
using System.Collections.Generic;
using Training.Aids;
using Training.Core;
using Training.Domain.Repos;

namespace Training.Domain.Common
{
    public abstract class BaseEntity<TData> : IBaseEntity
        where TData : class, IEntityData, new()
    {
        protected readonly TData data;

        protected BaseEntity() : this(null) { }
        protected BaseEntity(TData d) => data = d;

        public TData Data => Copy.Members(data, new TData()) ?? new TData();  // aidsi, core
        public string Id => Data?.Id ?? "Unspecified";
        public byte[] RowVersion => Data?.RowVersion ?? Array.Empty<byte>();

        internal static Lazy<ICollection<TEntity>> getLazy<TEntity, TRepo>(Func<TRepo, ICollection<TEntity>> func)
            where TEntity : IBaseEntity where TRepo : IRepo<TEntity>
            => new(() => func(getRepo<TRepo>()));

        internal static Lazy<TEntity> getLazy<TEntity, TRepo>(Func<TRepo, TEntity> func)
            where TEntity : IBaseEntity where TRepo : IRepo<TEntity> =>
            new(() => func(getRepo<TRepo>()));

        internal static TRepo getRepo<TRepo>() => new GetRepo().Instance<TRepo>();
    }
}
