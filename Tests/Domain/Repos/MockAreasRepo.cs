using System.Collections.Generic;
using Training.Domain;
using Training.Domain.Repos;

namespace Training.Tests.Domain.Repos
{
    public class MockAreasRepo : TestRepo<Area>, IAreasRepo
    {
        public List<Area> GetByAdministratorId(string id) => getList($"GetByAdministratorId {id}");
    }
}
