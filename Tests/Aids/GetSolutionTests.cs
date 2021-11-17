using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Training.Aids;

namespace Training.Tests.Aids
{
    [TestClass]
    public class GetSolutionTests : BaseTests
    {
        [TestMethod]
        public void ReferenceAssembliesTests()
        {
            var assemblies
                = GetSolution
                    .ReferenceAssemblies("Training.Tests")
                    .Where(x => x.FullName?.StartsWith("Training") ?? false)
                    .ToList();

            AreEqual(8, assemblies.Count);
        }
    }
}
