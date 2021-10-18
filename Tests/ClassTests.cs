using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public abstract class ClassTests<TClass, TBaseClass>
        : AbstractClassTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class
    {
        [TestMethod] public override void IsAbstractTest() => IsFalse(type.IsAbstract);
        protected override TClass GetObject() => GetRandom.ObjectOf<TClass>();
        [TestMethod]
        public virtual void CanCreate()
            => Assert.IsInstanceOfType(new TClass(), typeof(TClass));
    }
}
