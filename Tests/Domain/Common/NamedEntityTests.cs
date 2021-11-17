using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Aids;
using Training.Data;
using Training.Domain.Common;

namespace Training.Tests.Domain.Common
{
    [TestClass]
    public class NamedEntityTests : AbstractClassTests<NamedEntity<AreaData>, BaseEntity<AreaData>>
    {
        private class testClass : NamedEntity<AreaData>
        {
            public testClass(AreaData d = null) : base(d) { }
        }

        protected override NamedEntity<AreaData> GetObject() => new testClass(GetRandom.ObjectOf<AreaData>());

        [TestMethod] public void NameTest() => IsReadOnlyProperty(obj.Data.Name);
    }
}
