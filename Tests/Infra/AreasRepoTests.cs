using Training.Data;
using Training.Domain;
using Training.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Infra
{
    public class AreasRepoTests : InMemoryRepoTests<AreasRepo, Area, AreaData>
    {
        protected override Area createEntity(AreaData d) => new(d);
        protected override AreasRepo createRepo(ApplicationDbContext c) => new(c);
        [TestMethod]
        public void GetByAdministratorIdTest()
            => getListByIdTest(id => obj.GetByAreaBossId(id), (data, id) => data.AreaBossId = id);
    }
}
