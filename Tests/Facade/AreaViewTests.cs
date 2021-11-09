using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Facade;
using Training.Facade.Common;

namespace Training.Tests.Facade
{
    [TestClass]
    public class AreaViewTests: SealedClassTests<AreaView, NamedView>
    {
        [TestMethod] public void AreaBossIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void AreaBossNameTest() => IsReadWriteProperty<string>();
    }
}
