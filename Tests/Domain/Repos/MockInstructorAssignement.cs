using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain;
using Training.Domain.Repos;

namespace Training.Tests.Domain.Repos
{
    public class MockInstructorAssignement : TestRepo<InstructorAssignement>, IInstructorAssignementsRepo
    {
        public List<InstructorAssignement> GetByInstructorId(string id) => getList($"GetByInstructorId {id}");
        

        public List<InstructorAssignement> GetByTrainingCourseId(string id) => getList($"GetByTrainingCourseId {id}");
        
    }
}
