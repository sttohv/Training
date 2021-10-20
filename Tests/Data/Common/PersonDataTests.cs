using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Data.Common;

namespace Training.Tests.Data.Common
{
    [TestClass]
    public class PersonDataTests : SealedClassTests<UserData, IdentityUser>
    {
        [TestMethod] public void LastNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void FirstMidNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PhotoTest() => IsReadWriteProperty<byte[]>();
        [TestMethod] public void ValidFromTest() => IsReadWriteProperty<DateTime?>();
        [TestMethod] public void ValidToTest() => IsReadWriteProperty<DateTime?>();
    }
}
