using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain;
using Training.Domain.Repos;

namespace Training.Tests.Domain.Repos
{
    public class MockEnrollmentsRepo : TestRepo<Enrollement>, IEnrollementsRepo
    {
        public List<Enrollement> GetByTrainingCourseId(string id) => getList($"GetByTrainingCourseId {id}");
        public List<Enrollement> GetByUserId(string id) => getList($"GetByUserId {id}");
    }
}
