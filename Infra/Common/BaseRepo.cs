using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Aids;
using Training.Core;

namespace Training.Infra.Common
{
    public abstract class BaseRepo<T>
        where T : class, IEntityData, new()
    {
        protected internal readonly DbSet<T> dbSet;
        protected internal readonly DbContext db;
        public string ErrorMessage { get; protected set; }
        public T EntityInDb { get; protected set; }
        protected BaseRepo(DbContext c = null, DbSet<T> s = null)
        {
            dbSet = s;
            db = c;
        }
        protected internal async Task<List<T>> getAsync() => await createSql().ToListAsync();
        protected internal List<T> get() => createSql().ToList();
        protected internal T get(string id)
        {
            if (id is null) return null;
            var o = dbSet?.AsNoTracking().FirstOrDefault(m => m.Id == id);
            return o;
        }
        protected internal virtual IQueryable<T> createSql() => dbSet.AsNoTracking();
        protected internal async Task<T> getAsync(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            var o = await dbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            return o;
        }
        protected internal async Task<bool> delete(T obj)
        {
            var o = await dbSet.FindAsync(obj.Id);
            var isOk = await isEntityOk(o, ErrorMessages.ConcurrencyOnDelete);
            if (isOk) dbSet.Remove(o);
            await db.SaveChangesAsync();
            return isOk;
        }
        protected internal async Task<bool> add(T obj)
        {
            var isOk = await isEntityOk(obj, true);
            if (isOk) await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return isOk;
        }
        protected internal async Task<bool> update(T obj)
        {
            var o = await dbSet.FindAsync(obj.Id);
            Copy.Members(obj, o);
            var isOk = await isEntityOk(o, ErrorMessages.ConcurrencyOnEdit);
            if (isOk) dbSet.Update(o);
            await db.SaveChangesAsync();
            return isOk;
        }
        internal static bool byteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
            => a1.SequenceEqual(a2);
        private bool errorMessage(string msg)
        {
            ErrorMessage = msg;
            return false;
        }
        internal async Task<bool> isEntityOk(T obj,
            string concurrencyErrorMsg)
        {
            return await isEntityOk(obj, false)
                   && isCorrectVersion(obj, concurrencyErrorMsg);
        }
        private async Task<bool> isEntityOk(T obj, bool isNewItem)
        {
            if (obj is null) return errorMessage("Item is null");
            if (dbSet is null) return errorMessage("DbSet is null");
            EntityInDb = await getAsync(obj.Id);
            return (EntityInDb is null) == isNewItem
                   || errorMessage(
                       isNewItem
                           ? $"Item with id = <{obj.Id}> already in database"
                           : $"No item with id = <{obj.Id}> in database");
        }
        internal bool isCorrectVersion(T obj,
            string concurrencyErrorMsg)
        {
            return byteArrayCompare(obj?.RowVersion, EntityInDb?.RowVersion)
                   || errorMessage(concurrencyErrorMsg);
        }

    }


}
