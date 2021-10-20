using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;

namespace Training.Tests.Aids
{
    [TestClass]
    public class CreateNewTests : StaticClassTests
    {
        internal class TestClassStr
        {
            public TestClassStr(string s) { strField = s; }
            protected internal readonly string strField;
        }
        internal class TestClassInt
        {
            public TestClassInt(int i) { intField = i; }
            protected internal readonly int intField;
        }
        [TestInitialize] public void TestInitialize() => type = typeof(CreateNew);

        [TestMethod]
        public void InstanceTest()
        {
            TestCreate<TestClassStr>();
            TestCreate<TestClassInt>();
            TestCreate<CreateNewTests>();
        }
        [DataRow(typeof(TestClassStr))]
        [DataRow(typeof(TestClassInt))]
        [DataRow(typeof(CreateNewTests))]
        [DataTestMethod]
        public void InstanceTestByType(Type t) => TestCreate(t);
        private static void TestCreate(Type t)
        {
            var o = CreateNew.Instance(t);
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, t);
        }
        private static void TestCreate<T>()
        {
            var o = CreateNew.Instance<T>();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(T));
        }
    }
}
