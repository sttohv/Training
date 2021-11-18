using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;

namespace Training.Tests.Domain
{
    [TestClass] public class InstructorAssignementTests :SealedClassTests<InstructorAssignement, BaseEntity<InstructorAssignementData>>
    {
        protected override InstructorAssignement GetObject() => new(GetRandom.ObjectOf<InstructorAssignementData>());

        [TestMethod] public void LocationTest() => IsReadOnlyProperty(obj.Data.Location);
        [TestMethod] public void TrainingCourseIdTest() => IsReadOnlyProperty(obj.Data.TrainingCourseId);
        [TestMethod] public void UserIdTest() => IsReadOnlyProperty(obj.Data.UserId);
        [TestMethod] public void TrainingCourseTest() => LazyTest(() => obj.trainingCourse.IsValueCreated,
            () => obj.TrainingCourse);
        [TestMethod]
        public void UserTest() => LazyTest(() => obj.user.IsValueCreated,
        () => obj.User);

    }
}
