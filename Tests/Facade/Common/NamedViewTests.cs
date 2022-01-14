

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Facade.Common;

namespace Training.Tests.Facade.Common
{
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, BaseView>
    {
        private class testClass : NamedView { }

        protected override NamedView GetObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void NameTest() => IsReadWriteProperty<string>();

    }
}
