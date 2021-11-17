using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;

namespace Training.Tests.Domain
{
    [TestClass]
    public class TrainingCourseTests : SealedClassTests<TrainingCourse, BaseEntity<TrainingCourseData>>
    {

        protected override TrainingCourse GetObject() => new(GetRandom.ObjectOf<TrainingCourseData>());
        [TestMethod] public void TitleTest() => IsReadOnlyProperty(obj.Data.Title);
        [TestMethod] public void MaxPeopleInTrainingTest() => IsReadOnlyProperty(obj.Data.MaxPeopleInTraining);
        [TestMethod] public void AreaIdTest() => IsReadOnlyProperty(obj.Data.AreaId);
        [TestMethod] public void CourseTimeTest() => IsReadOnlyProperty(obj.Data.CourseTime);

        [TestMethod]
        public void AreaTest() => LazyTest(()
            => obj.area.IsValueCreated, () => obj.Area);
        [TestMethod]
        public void UsersTest() => LazyTest(() => obj.enrollements.IsValueCreated,
            () => obj.Users);
        [TestMethod]
        public void EnrollmentsTest() => LazyTest(()
            => obj.enrollements.IsValueCreated, () => obj.Enrollments);
        [TestMethod]
        public void InstructorAssignementTest()
            => LazyTest(() => obj.instructorAssignement.IsValueCreated, () => obj.InstructorAssignement);

    }
}
