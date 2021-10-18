using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data
{
    [TestClass]
    public class InstructorAssignementDataTests : SealedClassTests<InstructorAssignementData, BaseData>
    {
        [TestMethod] public void TrainingCourseIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PersonIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void LocationTest() => IsReadWriteProperty<string>();

    }
}
