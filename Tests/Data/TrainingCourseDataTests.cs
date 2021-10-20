using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Data.Common;

namespace Training.Tests.Data
{
    [TestClass]
    public class TrainingCourseDataTests : SealedClassTests<TrainingCourseData, BaseData>
    {
        [TestMethod] public void TitleTest() => IsReadWriteProperty<string>();
        [TestMethod] public void AreaIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void MaxPeopleInTrainingTest() => IsReadWriteProperty<int>();

    }
}
