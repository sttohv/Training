

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Infra.Common;

namespace Training.Tests.Infra.Common
{
    [TestClass]
    public class DbInitializerTests : StaticClassTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(DbInitializer);
        }
    }
}
