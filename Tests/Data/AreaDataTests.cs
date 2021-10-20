using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Data.Common;

namespace Training.Tests.Data
{
    [TestClass]
    public class AreaDataTests: SealedClassTests<AreaData, BaseData>
    {
        [TestMethod] public void AreaNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void AreaBossIdTest() => IsReadWriteProperty<string>();
    }
}
