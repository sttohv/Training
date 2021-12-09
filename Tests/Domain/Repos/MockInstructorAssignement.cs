using System.Collections.Generic;
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
