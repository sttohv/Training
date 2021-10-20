﻿using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public abstract class StaticClassTests : BaseTests
    {
        private const string notSpecified = "Class is not specified";
        private List<string> Members { get; set; }
        protected Type type;
        protected string TypeName => GetName();
        private string GetName()
        {
            var s = type.Name;
            var index = s.IndexOf("`", StringComparison.Ordinal);
            if (index > -1) s = s.Substring(0, index);
            return s;
        }
        [TestMethod]
        public virtual void IsStaticTest()
            => IsTrue(type.IsAbstract && type.IsClass && type.IsSealed);
        [TestMethod]
        public virtual void IsTested()
        {
            if (type == null) NotTested(notSpecified);
            var m = GetClass.Members(type, PublicFlagsFor.Declared);
            Members = m.Select(e => e.Name).ToList();
            RemoveTested();
            if (Members.Count == 0) return;
            NotTested("<{0}> is not tested", Members[0]);
        }
        [TestMethod]
        public virtual void IsSpecifiedClassTested()
        {
            if (type == null) Assert.Inconclusive(notSpecified);
            var className = GetType().Name;
            IsTrue(className.StartsWith(TypeName));
        }
        private void RemoveTested()
        {
            var tests = GetType().GetMembers().Select(e => e.Name).ToList();
            for (var i = Members.Count; i > 0; i--)
            {
                var m = Members[i - 1] + "Test";
                var isTested = tests.Find(o => o == m);
                if (string.IsNullOrEmpty(isTested)) continue;
                Members.RemoveAt(i - 1);
            }
        }
        protected PropertyInfo IsProperty<T>(bool canWrite = true)
        {
            var name = GetPropertyName();
            var propertyInfo = type.GetProperty(name);
            Assert.IsNotNull(propertyInfo, "Not found");
            Assert.AreEqual(typeof(T), propertyInfo.PropertyType, "Wrong type");
            Assert.AreEqual(true, propertyInfo.CanRead, "Cant read");
            Assert.AreEqual(canWrite, propertyInfo.CanWrite, "CanWrite is wrong");
            return propertyInfo;
        }
        protected void IsReadWriteProperty<T>()
        {
            var propertyInfo = IsProperty<T>();
            var actual = GetPropertyValue<T>(true);
            var expected = GetValue(actual);
            var current = GetCurrentValues();
            SetPropertyValue(propertyInfo, expected);
            actual = GetPropertyValue<T>(true);
            AreEqual(expected, actual);
            ArePropertiesEqual(current, GetCurrentValues(), propertyInfo.Name);
        }
        private static T GetValue<T>(T value)
        {
            var v = (T)GetRandom.ValueOf<T>();
            while (value.Equals(v))
            {
                v = (T)GetRandom.ValueOf<T>();
            }
            return v;
        }
        protected virtual void SetPropertyValue<T>(PropertyInfo p, T newValue) { }
        protected virtual dynamic GetCurrentValues() => null;
        protected void IsReadOnlyProperty<T>() => IsProperty<T>(false);
        protected void IsReadOnlyProperty<T>(T expected)
        {
            var actual = GetPropertyValue<T>();
            AreEqual(expected, actual);
        }
        protected virtual T GetPropertyValue<T>(bool canWrite = false) => default;
        private readonly string[] notPropertyNames = { nameof(GetPropertyName),
            nameof(IsReadOnlyProperty) , nameof(IsReadWriteProperty), nameof(IsProperty)
            , nameof(GetPropertyValue), nameof(GetCurrentValues),
            nameof(SetPropertyValue), nameof(GetValue)};
        protected string GetPropertyName()
        {
            var stack = new StackTrace();
            for (var idx = 0; idx < stack.FrameCount; idx++)
            {
                var n = stack.GetFrame(idx)?.GetMethod()?.Name;
                if (notPropertyNames.Contains(n)) continue;
                return n?.Replace("Test", string.Empty);
            }
            return string.Empty;
        }
        protected static void ArePropertiesNotEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) AreEqual(expectedValue, actualValue);
                else AreNotEqual(expectedValue, actualValue);
            }
        }
        protected static void ArePropertiesEqual<T>(T expected, T actual, params string[] exceptProperties)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                var expectedValue = p.GetValue(expected);
                var actualValue = p.GetValue(actual);
                if (exceptProperties.Contains(p.Name)) AreNotEqual(expectedValue, actualValue);
                else AreEqual(expectedValue, actualValue);
            }
        }
    }
}