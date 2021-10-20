using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Data.Common;

namespace Training.Tests.Data
{
    [TestClass]
    public class ContactInfoDataTests: SealedClassTests<ContactInfoData, BaseData>
    {
        [TestMethod] public void PhoneNumberTest() => IsReadWriteProperty<string>();
        [TestMethod] public void MailAddressTest() => IsReadWriteProperty<string>();

    }
}
