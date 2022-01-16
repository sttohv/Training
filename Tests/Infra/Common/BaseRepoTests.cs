using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Infra.Common;
using Training.Data;

namespace Training.Tests.Infra.Common
{
    [TestClass]
    public class BaseRepoTests : AbstractClassTests<BaseRepo<TrainingCourseData>, object>
    {
        [TestMethod] public void ErrorMessageTest() => IsProperty<string>();
        [TestMethod] public void EntityInDbTest() => IsProperty<TrainingCourseData>();
    }
}
