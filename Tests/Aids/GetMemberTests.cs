using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;

namespace Training.Tests.Aids
{
    [TestClass]
    public class GetMemberTests
    {

        private readonly string stringField = null;
        private string StringProperty { get; } = null;

        [TestMethod]
        public void NameTestField()
            => Assert.AreEqual("stringField",
                GetMember.Name<GetMemberTests>(x => x.stringField));
        [TestMethod]
        public void NameTestProperty()
            => Assert.AreEqual("StringProperty",
                GetMember.Name<GetMemberTests>(x => x.StringProperty));
        [TestMethod]
        public void NameTestFunction()
            => Assert.AreEqual("ToString",
                GetMember.Name<object>(x => x.ToString()));
        [TestMethod]
        public void NameTestMethod()
            => Assert.AreEqual("NameTestMethod",
                GetMember.Name<GetMemberTests>(x => x.NameTestMethod()));
    }
}
