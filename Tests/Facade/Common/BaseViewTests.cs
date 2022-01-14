using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Aids;
using Training.Core;
using Training.Facade.Common;

namespace Training.Tests.Facade.Common
{
    [TestClass]
    public class BaseViewTests : AbstractClassTests<BaseView, UniqueItem>
    {
        private class TestClass : BaseView { }

        protected override BaseView GetObject() => GetRandom.ObjectOf<TestClass>();
        [TestMethod] public void RowVersionTest() => IsReadWriteProperty<byte[]>();

    }
}
