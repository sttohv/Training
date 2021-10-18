using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class SealedClassTests<TClass, TBaseClass>
        : ClassTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class
    {

        [TestMethod] public override void IsSealedTest() => IsTrue(type.IsSealed);
    }
}
