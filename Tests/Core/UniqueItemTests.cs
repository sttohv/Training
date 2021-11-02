using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Training.Aids;
using Training.Core;

namespace Training.Tests.Core
{
    [TestClass]
    public class UniqueItemTests : AbstractClassTests<UniqueItem, object>
    {
        private class testClass : UniqueItem { }
        protected override UniqueItem GetObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void IdTest() => IsReadWriteProperty<string>();
        [TestMethod]
        public void DefaultIdTest()
        {
            obj = new testClass();
            IsFalse(string.IsNullOrWhiteSpace(obj.Id));
        }
        [TestMethod]
        public void DefaultIdIsGuidTest()
        {
            obj = new testClass();
            var guid = Guid.Parse(obj.Id);
            Assert.AreEqual(obj.Id, guid.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AnyStringIsNotGuidTest()
        {
            var s = GetRandom.String();
            var _ = Guid.Parse(s);
        }
    }
}
