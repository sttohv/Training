using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;

namespace Training.Tests.Domain
{
    [TestClass]
    public class EnrollementTests:SealedClassTests<Enrollement, BaseEntity<EnrollementData>>
    {
        protected override Enrollement GetObject() => new(GetRandom.ObjectOf<EnrollementData>());
        [TestMethod] public void UserIdTest() => IsReadOnlyProperty(obj.Data.UserId);
        [TestMethod] public void TrainingCourseIdTest() => IsReadOnlyProperty(obj.Data.TrainingCourseId);
        [TestMethod] public void TrainingCourseTitleTest() => IsReadOnlyProperty(obj.TrainingCourse?.Title ?? string.Empty);
        [TestMethod] public void UserTest() => LazyTest(() => obj.user.IsValueCreated, () => obj.User);
        [TestMethod] public void TrainingCourseTest() => LazyTest(() => obj.trainingCourse.IsValueCreated, () => obj.TrainingCourse);

    }
}
