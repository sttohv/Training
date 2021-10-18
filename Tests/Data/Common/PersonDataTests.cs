using Aids;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Data.Common
{
    [TestClass]
    public class PersonDataTests :AbstractClassTests<PersonData, BaseData>
    {
        private class testClass : PersonData { }
        protected override PersonData GetObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void LastNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void FirstMidNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PhotoTest() => IsReadWriteProperty<byte[]>();
        [TestMethod] public void ValidFromTest() => IsReadWriteProperty<DateTime?>();
        [TestMethod] public void ValidToTest() => IsReadWriteProperty<DateTime?>();
    }
}
