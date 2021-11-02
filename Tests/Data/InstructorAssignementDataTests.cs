using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Data.Common;

namespace Training.Tests.Data
{
    [TestClass]
    public class InstructorAssignementDataTests : SealedClassTests<InstructorAssignementData, BaseData>
    {
        [TestMethod] public void TrainingCourseIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void UserIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void LocationTest() => IsReadWriteProperty<string>();

    }
}
