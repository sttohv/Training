using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Training.Domain.Common;
using Training.Domain.Repos;
using Training.Tests.Domain.Repos;

namespace Training.Tests.Domain.Common
{
    [TestClass]
    public class GetRepoTests : SealedClassTests<GetRepo, object>
    {
        private IServiceProvider provider { get; set; }
        protected override GetRepo GetObject() => new(provider);
        [TestCleanup] public void TestCleanup() => GetRepo.SetProvider(null);
        [TestMethod] public void ProviderIsNullTest() => IsNull(obj.provider);
        [TestMethod] public void InstanceIsNullTest() => IsNull(GetRepo.instance);
        [TestMethod]
        public void CanCreateTest()
        {
            initMock();
            AreNotEqual(provider, GetRepo.instance);
            AreEqual(provider, obj.provider);
        }
        [TestMethod]
        public void SetProviderTest()
        {
            var p = new MockServiceProvider(null);
            GetRepo.SetProvider(p);
            IsNull(obj.provider);
            AreEqual(p, GetRepo.instance);
        }
        [TestMethod]
        public void CreateAfterSetTest()
        {
            var p = new MockServiceProvider(null);
            GetRepo.SetProvider(p);
            obj = new GetRepo();
            AreEqual(p, GetRepo.instance);
            AreEqual(p, obj.provider);
        }
        [TestMethod]
        public void InstanceWithTypeTest()
        {
            var repo = initMock();
            var r = obj.Instance(typeof(ITrainingCoursesRepo));
            AreEqual(repo, r);
        }
        [TestMethod]
        public void InstanceTest()
        {
            var repo = initMock();
            var r = obj.Instance<ITrainingCoursesRepo>();
            AreEqual(repo, r);
        }
        private MockTrainingCoursesRepo initMock()
        {
            var r = new MockTrainingCoursesRepo();
            provider = new MockServiceProvider(r);
            obj = GetObject();
            return r;
        }
    }
}
