using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Training.Core;

namespace Training.Infra.Common
{
    public abstract class CrudRepo<TEntity, TData> : BaseRepo<TData>
       where TData : class, IEntityData, new()
    {
        protected CrudRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }

        public async Task<TEntity> GetAsync(string id) => toEntity(await getAsync(id));
        public async Task<List<TEntity>> GetAsync() => (await getAsync()).Select(toEntity).ToList();

        public TEntity Get(string id) => toEntity(get(id));
        public List<TEntity> Get() => get().Select(toEntity).ToList();

        public virtual async Task<bool> DeleteAsync(TEntity e) => await delete(toData(e));
        public virtual async Task<bool> AddAsync(TEntity e) => await add(toData(e));
        public virtual async Task<bool> UpdateAsync(TEntity e) => await update(toData(e));

        public new TEntity EntityInDb => toEntity(base.EntityInDb);

        protected internal List<TEntity> getRelated(Expression<Func<TData, bool>> predicate) => dbSet?
            .Where(predicate)
            .AsNoTracking()?
            .AsEnumerable()
            .Select(toEntity)
            .ToList() ?? new List<TEntity>();

        protected internal abstract TEntity toEntity(TData d);
        protected internal abstract TData toData(TEntity e);

    }
}
