using Training.Aids;
using Training.Core;
using Training.Data.Common;
using Training.Domain.Common;
using Training.Domain.Repos;
using Training.Infra;
using Training.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Training.Tests
{
    public abstract class InMemoryRepoTests<TRepo, TEntity, TData>
        : SealedClassTests<TRepo, PagedRepo<TEntity, TData>>
        where TRepo : PagedRepo<TEntity, TData>, IRepo<TEntity>, new()
        where TEntity : BaseEntity<TData>
        where TData : BaseData, IEntityData, new()
    {
        protected abstract TEntity createEntity(TData d);
        protected abstract TRepo createRepo(ApplicationDbContext c);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            obj = createRepo(new ApplicationDbContext(options));
        }

        [TestMethod]
        public void ToDataTest()
        {
            var expected = GetRandom.ObjectOf<TData>();
            var o = createEntity(expected);
            var actual = obj.toData(o);
            ArePropertiesEqual(expected, actual);
        }
        [TestMethod]
        public void ToEntityTest()
        {
            var expected = GetRandom.ObjectOf<TData>();
            var actual = obj.toEntity(expected);
            ArePropertiesEqual(expected, actual.Data);
        }
        [TestMethod]
        public void ApplyFiltersTest()
        {

            var query = obj.createSql();

            obj.SearchString = GetRandom.String();
            obj.PageIndex = 0;
            var expected = obj.applyFilters(query).Expression.ToString();
            var actual = obj.createSql().Expression.ToString();
            AreEqual(expected, actual);
        }

        protected void getListByIdTest(Func<string, List<TEntity>> getById, Action<TData, string> setId)
        {
            var l = getById(null);
            AreEqual(0, l.Count);

            var id = GetRandom.String();
            l = getById(id);
            AreEqual(0, l.Count);
            var count = GetRandom.UInt8(10, 20);
            for (var i = 1; i <= count; i++)
            {
                var d = GetRandom.ObjectOf<TData>();
                if (i % 4 == 0) setId(d, id);
                obj.dbSet.Add(d);
            }
            obj.db.SaveChanges();
            l = getById(id);
            AreEqual(count / 4, l.Count);
        }
    }
}
