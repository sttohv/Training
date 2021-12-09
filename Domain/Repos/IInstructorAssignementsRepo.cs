using System.Collections.Generic;

namespace Training.Domain.Repos
{
    public interface IInstructorAssignementsRepo : IRepo<InstructorAssignement>
    {
        List<InstructorAssignement> GetByTrainingCourseId(string id);
        List<InstructorAssignement> GetByInstructorId(string id);
    }
}
