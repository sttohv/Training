using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Data;

namespace Training.Tests.Data
{
    [TestClass]
    public class UserDataTests : SealedClassTests<UserData, IdentityUser>
    {
        [TestMethod] public void LastNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void FirstMidNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void PhotoTest() => IsReadWriteProperty<byte[]>();
        [TestMethod] public void ValidFromTest() => IsReadWriteProperty<DateTime?>();
        [TestMethod] public void ValidToTest() => IsReadWriteProperty<DateTime?>();
    }
}
