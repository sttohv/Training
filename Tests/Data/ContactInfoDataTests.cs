using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class ContactInfoDataTests: SealedClassTests<ContactInfoData, BaseData>
    {
        [TestMethod] public void PhoneNumberTest() => IsReadWriteProperty<string>();
        [TestMethod] public void MailAddressTest() => IsReadWriteProperty<string>();

    }
}
