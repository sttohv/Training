using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Domain;
using Training.Infra;

namespace Training.Tests.Infra
{
    public class InstructorAssignementRepoTests
        :InMemoryRepoTests<InstructorAssignementsRepo, InstructorAssignement, InstructorAssignementData>
    {
        protected override InstructorAssignement createEntity(InstructorAssignementData d) => new(d);
        protected override InstructorAssignementsRepo createRepo(ApplicationDbContext c) => new(c);
        [TestMethod]
        public void GetByCourseIdTest()
            => getListByIdTest(id => obj.GetByTrainingCourseId(id), (data, id) => data.TrainingCourseId = id);
        [TestMethod]
        public void GetByStudentIdTest()
            => getListByIdTest(id => obj.GetByInstructorId(id), (data, id) => data.UserId = id);
    }
}
