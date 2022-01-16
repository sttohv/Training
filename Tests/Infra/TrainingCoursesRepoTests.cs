using Training.Data;
using Training.Domain;
using Training.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Infra
{
    [TestClass]
    public class TrainingCoursesRepoTests
       : InMemoryRepoTests<TrainingCoursesRepo, TrainingCourse, TrainingCourseData>
    {
        protected override TrainingCourse createEntity(TrainingCourseData d) => new(d);

        protected override TrainingCoursesRepo createRepo(ApplicationDbContext c) => new(c);
    }
}
