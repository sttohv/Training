using Aids;
using Core;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Common
{
    [TestClass]
    public class BaseDataTests : AbstractClassTests<BaseData, UniqueItem>
    {
        private class TestClass : BaseData { }
        protected override BaseData GetObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod] public void RowVersionTest() => IsReadWriteProperty<byte[]>();

    }
}
