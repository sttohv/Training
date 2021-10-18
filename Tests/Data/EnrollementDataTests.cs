using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class EnrollementDataTests: SealedClassTests<EnrollementData, BaseData>
    {
        [TestMethod] public void TrainingCourseIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PersonIdTests() => IsReadWriteProperty<string>();

    }
}
