using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Aids;
using Training.Core;
using Training.Data.Common;

namespace Training.Infra.Common
{
    public abstract class BaseRepo<T>
        where T : BaseData, IEntityData, new()
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
        protected internal async Task<List<T>> GetAsync() => await CreateSql().ToListAsync();
        protected internal List<T> Get() => CreateSql().ToList();
        protected internal T Get(string id)
        {
            if (id is null) return null;
            var o = dbSet?.AsNoTracking().FirstOrDefault(m => m.Id == id);
            return o;
        }
        protected internal virtual IQueryable<T> CreateSql() => dbSet.AsNoTracking();
        protected internal async Task<T> GetAsync(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            var o = await dbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            return o;
        }
        protected internal async Task<bool> Delete(T obj)
        {
            var o = await dbSet.FindAsync(obj.Id);
            var isOk = await IsEntityOk(o, ErrorMessages.ConcurrencyOnDelete);
            if (isOk) dbSet.Remove(o);
            await db.SaveChangesAsync();
            return isOk;
        }
        protected internal async Task<bool> Add(T obj)
        {
            var isOk = await IsEntityOk(obj, true);
            if (isOk) await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return isOk;
        }
        protected internal async Task<bool> Update(T obj)
        {
            var o = await dbSet.FindAsync(obj.Id);
            Copy.Members(obj, o);
            var isOk = await IsEntityOk(o, ErrorMessages.ConcurrencyOnEdit);
            if (isOk) dbSet.Update(o);
            await db.SaveChangesAsync();
            return isOk;
        }
        internal static bool ByteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
            => a1.SequenceEqual(a2);
        private bool errorMessage(string msg)
        {
            ErrorMessage = msg;
            return false;
        }
        internal async Task<bool> IsEntityOk(T obj,
            string concurrencyErrorMsg)
        {
            return await IsEntityOk(obj, false)
                   && IsCorrectVersion(obj, concurrencyErrorMsg);
        }
        private async Task<bool> IsEntityOk(T obj, bool isNewItem)
        {
            if (obj is null) return errorMessage("Item is null");
            if (dbSet is null) return errorMessage("DbSet is null");
            EntityInDb = await GetAsync(obj.Id);
            return (EntityInDb is null) == isNewItem
                   || errorMessage(
                       isNewItem
                           ? $"Item with id = <{obj.Id}> already in database"
                           : $"No item with id = <{obj.Id}> in database");
        }
        internal bool IsCorrectVersion(T obj,
            string concurrencyErrorMsg)
        {
            return ByteArrayCompare(obj?.RowVersion, EntityInDb?.RowVersion)
                   || errorMessage(concurrencyErrorMsg);
        }

    }
}
