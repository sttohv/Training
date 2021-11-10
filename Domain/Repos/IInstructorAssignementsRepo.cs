using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Repos
{
    public interface IInstructorAssignementsRepo : IRepo<InstructorAssignement>
    {
        List<InstructorAssignement> GetByTrainingCourseId(string id);
        List<InstructorAssignement> GetByInstructorId(string id);
    }
}
