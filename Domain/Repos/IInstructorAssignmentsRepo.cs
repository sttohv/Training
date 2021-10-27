using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Repos
{
    public interface IInstructorAssignmentsRepo : IRepo<InstructorAssignement>
    {
        List<Enrollement> GetByTrainingCourseId(string id);
        List<Enrollement> GetByInstructorId(string id);
    }
}
