using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Training.Aids;
using Training.Data.Common;
using Training.Domain;
using Training.Domain.Common;

namespace Training.Tests.Domain
{
    [TestClass]
    public class UserTests : SealedClassTests<User, BaseEntity<UserData>>
    {

        protected override User GetObject() => new(GetRandom.ObjectOf<UserData>());
        [TestMethod] public void LastNameTest() => IsReadOnlyProperty(obj.Data.LastName);
        [TestMethod] public void FirstMidNameTest() => IsReadOnlyProperty(obj.Data.FirstMidName);
        [TestMethod] public void FullNameTest() => IsReadOnlyProperty($"{obj.LastName}, {obj.FirstMidName}");

        [TestMethod] public void PhotoTest() => IsReadOnlyProperty(obj.Data.Photo);

        [TestMethod] public void EnrollmentDateTest() => IsReadOnlyProperty(obj.Data.ValidFrom ?? DateTime.MinValue);

        //[TestMethod]
        //public void TrainingCoursesTest() => LazyTest(() => obj.enrollements.IsValueCreated,
        //    () => obj.TrainingCourses);
        [TestMethod] public void AreaIdTest() => IsReadOnlyProperty(obj.Data.AreadId);
        [TestMethod]
        public void AreaTest() => LazyTest(() => obj.area.IsValueCreated,
            () => obj.Area);

        [TestMethod]
        public void EnrollmentsTest() => LazyTest(() => obj.enrollements.IsValueCreated,
            () => obj.Enrollements);
    }
}
