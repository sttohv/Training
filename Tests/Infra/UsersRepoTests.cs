using Training.Data;
using Training.Domain;
using Training.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Infra
{
    [TestClass]
    public class UsersRepoTests : InMemoryRepoTests<UsersRepo, User, UserData>
    {
        protected override User createEntity(UserData d) => new(d);
        protected override UsersRepo createRepo(ApplicationDbContext c) => new(c);
    }
}
