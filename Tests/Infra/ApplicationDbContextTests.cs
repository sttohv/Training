using Training.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Tests.Infra
{
    [TestClass]
    public class ApplicationDbContextTests
       : ClassTests<ApplicationDbContext, IdentityDbContext>
    {
    }
}
