using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Domain;
using Training.Infra;

namespace Training.Tests.Infra
{
    [TestClass]
    public class EnrollementsRepoTests
        : InMemoryRepoTests<EnrollementsRepo, Enrollement, EnrollementData>
    {
        protected override Enrollement createEntity(EnrollementData d) => new(d);
        protected override EnrollementsRepo createRepo(ApplicationDbContext c) => new(c);
        [TestMethod]
        public void GetByCourseIdTest()
            => getListByIdTest(id => obj.GetByTrainingCourseId(id), (data, id) => data.TrainingCourseId = id);
        [TestMethod]
        public void GetByStudentIdTest()
            => getListByIdTest(id => obj.GetByUserId(id), (data, id) => data.UserId = id);
    }
}
