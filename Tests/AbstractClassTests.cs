using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : StaticClassTests
    where TClass : class
    where TBaseClass : class
    {
        protected TClass obj;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);
            obj = GetObject();
        }
        protected virtual TClass GetObject() => null;
        [TestMethod]
        public virtual void BaseClassTest() =>
            AreEqual(typeof(TBaseClass), typeof(TClass).BaseType);
        [TestMethod] public override void IsStaticTest() => IsFalse(type.IsAbstract && type.IsClass && type.IsSealed);
        [TestMethod] public virtual void IsSealedTest() => IsFalse(type.IsSealed);
        [TestMethod] public virtual void IsAbstractTest() => IsTrue(type.IsAbstract);
        [TestMethod] public virtual void IsClassTest() => IsTrue(type.IsClass);
        protected static void LazyTest<TResult>(Func<bool> isValueCreated, Func<TResult> getValue, bool valueIsNull = true)
        {
            IsFalse(isValueCreated());
            var d = getValue();
            IsTrue(isValueCreated());
            if (valueIsNull) IsNull(d); else IsNotNull(d);
        }
        protected override T GetPropertyValue<T>(bool canWrite = false)
        {
            var propertyInfo = IsProperty<T>(canWrite);
            var o = (T)propertyInfo.GetValue(obj);
            return o;
        }
        protected override void SetPropertyValue<T>(PropertyInfo p, T newValue)
            => p.SetValue(obj, newValue);

        protected override dynamic GetCurrentValues()
        {
            var o = GetObject();
            Copy.Members(obj, o);
            return o;
        }
    }
}
