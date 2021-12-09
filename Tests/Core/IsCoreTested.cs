using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Core
{
    [TestClass]
    public class IsCoreTested : AssemblyBaseTests
    {
        public IsCoreTested()
            : base($"{nameof(Training)}.{nameof(Core)}") { }
    }
}
