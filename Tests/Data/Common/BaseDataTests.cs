using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Core;
using Training.Data.Common;

namespace Training.Tests.Data.Common
{
    [TestClass]
    public class BaseDataTests : AbstractClassTests<BaseData, UniqueItem>
    {
        private class TestClass : BaseData { }
        protected override BaseData GetObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod] public void RowVersionTest() => IsReadWriteProperty<byte[]>();

    }
}
