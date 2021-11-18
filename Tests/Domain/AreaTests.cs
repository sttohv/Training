using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;

namespace Training.Tests.Domain
{
    [TestClass]
    public class AreaTests : SealedClassTests<Area, NamedEntity<AreaData>>
    {
        protected override Area GetObject() => new(GetRandom.ObjectOf<AreaData>());

        [TestMethod] public void AreaBossIdTest() => IsReadOnlyProperty(obj.AreaBossId);

        [TestMethod]
        public void AreaBossTest() => LazyTest(() => obj.areaBoss.IsValueCreated,
            () => obj.AreaBoss);
    }
}
