using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Aids
{
    [TestClass]
    public class IsAidsTested : AssemblyBaseTests
    {
        public IsAidsTested() : base($"{nameof(Training)}.{nameof(Training.Aids)}") { }
    }
}
