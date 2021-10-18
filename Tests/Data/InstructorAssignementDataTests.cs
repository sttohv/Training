using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Data
{
    public class InstructorAssignementDataTests : SealedClassTests<InstructorAssignementData, BaseData>
    {
        [TestMethod] public void TrainingCourseIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PersonIdTests() => IsReadWriteProperty<string>();
        [TestMethod] public void LocationTests() => IsReadWriteProperty<string>();

    }
}
