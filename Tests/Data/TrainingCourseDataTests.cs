using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class TrainingCourseDataTests : SealedClassTests<TrainingCourseData, BaseData>
    {
        [TestMethod] public void TitleTest() => IsReadWriteProperty<string>();
        [TestMethod] public void AreaIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void MaxPeopleInTrainingTest() => IsReadWriteProperty<int>();

    }
}
