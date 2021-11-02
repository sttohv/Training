using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Data.Common;

namespace Training.Tests.Data
{
    [TestClass]
    public class AreaDataTests: SealedClassTests<AreaData, NamedData>
    {
        [TestMethod] public void AreaBossIdTest() => IsReadWriteProperty<string>();
    }
}
