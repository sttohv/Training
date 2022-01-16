using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Infra;
using Training.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Training.Tests.Infra.Common
{
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<TrainingCourse, TrainingCourseData>
         , BaseRepo<TrainingCourseData>>
    {
        private class testRepo : CrudRepo<TrainingCourse, TrainingCourseData>
        {
            public testRepo(ApplicationDbContext c = null)
                : base(c, c?.TrainingCourses) { }
            protected internal override TrainingCourse toEntity(TrainingCourseData d) => new(d);
            protected internal override TrainingCourseData toData(TrainingCourse e) => e.Data;
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj.dbSet.RemoveRange(obj.dbSet);
            obj.db.SaveChanges();
        }
        protected override CrudRepo<TrainingCourse, TrainingCourseData> GetObject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            var c = new ApplicationDbContext(options);
            return new testRepo(c);
        }
        [TestMethod]
        public async Task GetTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            var o = await obj.GetAsync(d.Id);
            ArePropertiesNotEqual(d, o.Data);

            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();

            //do something
            o = await obj.GetAsync(d.Id);

            //post condition
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task DeleteTest()
        {

            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));

            //do something
            await obj.DeleteAsync(new TrainingCourse(d));

            //post condition
            o = await obj.GetAsync(d.Id);
            ArePropertiesNotEqual(d, o.Data);
        }
        [TestMethod]
        public async Task AddTest()
        {

            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            var o = await obj.GetAsync(d.Id);
            Assert.IsNotNull(o);
            ArePropertiesNotEqual(d, o.Data);

            //do something
            await obj.AddAsync(new TrainingCourse(d));

            //post condition
            o = await obj.GetAsync(d.Id);
            Assert.IsInstanceOfType(o, typeof(TrainingCourse));
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));
            var d1 = GetRandom.ObjectOf<TrainingCourseData>();
            d1.Id = o.Id;
            d1.RowVersion = o.RowVersion;
            //do something
            await obj.UpdateAsync(new TrainingCourse(d1));
            //post condition
            o = await obj.GetAsync(d.Id);
            ArePropertiesEqual(d1, o.Data, nameof(d.RowVersion));
            ArePropertiesEqual(d, d1);
        }
        [TestMethod]
        public async Task EntityInDbTest()
        {
            Assert.Inconclusive();
            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));
            var d1 = GetRandom.ObjectOf<TrainingCourseData>();
            d1.Id = o.Id;
            //do something
            AreEqual(false, await obj.UpdateAsync(new TrainingCourse(d1)));
            //post condition
            ArePropertiesEqual(d, obj.EntityInDb.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task GetListTest()
        {
            var l = await obj.GetAsync();
            AreEqual(0, l.Count);
            var count = GetRandom.UInt8(10, 20);
            for (var i = 1; i <= count; i++)
                await obj.dbSet.AddAsync(GetRandom.ObjectOf<TrainingCourseData>());
            await obj.db.SaveChangesAsync();
            l = await obj.GetAsync();
            AreEqual((int)count, l.Count);

        }
        [TestMethod]
        public async Task GetByIdTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<TrainingCourseData>();
            var o = obj.Get(d.Id);
            ArePropertiesNotEqual(d, o.Data);

            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();

            //do something
            o = obj.Get(d.Id);

            //post condition
            ArePropertiesEqual(d, o.Data, nameof(d.RowVersion));

        }
    }
}
