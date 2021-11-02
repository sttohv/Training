using Training.Aids;
using Training.Data;
using Training.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Domain.Common
{
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity<TrainingCourseData>, object>
    {
        private class TestClass : BaseEntity<TrainingCourseData>
        {
            public TestClass(TrainingCourseData d = null) : base(d) { }
        }

        protected override BaseEntity<TrainingCourseData> GetObject() => new TestClass(GetRandom.ObjectOf<TrainingCourseData>());

        [TestMethod]
        public void DataTest()
        {
            IsReadOnlyProperty<TrainingCourseData>();
            Assert.AreNotSame(obj.Data, obj.Data);
            Assert.AreNotEqual(obj.Data, obj.Data);
            ArePropertiesEqual(obj.Data, obj.Data);
            var actual = obj.Data;
            var expected = GetRandom.ObjectOf<TrainingCourseData>();
            Copy.Members(expected, actual);
            ArePropertiesEqual(expected, actual);
            ArePropertiesNotEqual(expected, obj.Data);
        }
        [TestMethod] public void IdTest() => IsReadOnlyProperty(obj.Data.Id);
        [TestMethod] public void RowVersionTest() => IsReadOnlyProperty(obj.Data.RowVersion);
    }
}
