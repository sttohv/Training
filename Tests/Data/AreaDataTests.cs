using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AreaDataTests: SealedClassTests<AreaData, BaseData>
    {
        [TestMethod] public void AreaNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void AreaBossIdTest() => IsReadWriteProperty<string>();
    }
}
