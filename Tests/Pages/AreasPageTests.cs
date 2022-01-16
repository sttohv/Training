using Training.Domain;
using Training.Domain.Repos;
using Training.Facade;
using Training.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Training.Tests.Pages.Common;

namespace Training.Tests.Pages
{
    [TestClass]
    public class AreasPageTests : BasePageTests<Area, AreaView>
    {
        private class testAreasRepo : TestRepo<Area>, IAreasRepo
        {
            public List<Area> GetByAdministratorId(string id)
                => new();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new testAreasRepo();
            pageModel = new AreasPage((IAreasRepo)mockRepo);
        }
    }
}
