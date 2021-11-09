using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain;
using Training.Infra.Common;

namespace Training.Infra
{
    public sealed class InstructorAssignementsRepo : PagedRepo<InstructorAssignement, InstructorAssignementData>, IInstructorAssignementRepo
    {
        public InstructorAssignementsRepo() : this(null) { }
        public InstructorAssignementsRepo(ApplicationDbContext c) : base(c, c?.InstructorAssignements) { }

        protected internal override InstructorAssignement toEntity(InstructorAssignementData d) => new(d);

        protected internal override InstructorAssignementData toData(InstructorAssignement s) => s?.Data ?? new InstructorAssignementData();

        public List<InstructorAssignement> GetByTrainingCourseId(string id)
            => getRelated(x => x.TrainingCourseId == id);

        public List<InstructorAssignement> GetByInstructorId(string id)
            => getRelated(x => x.UserId == id);
    }
}
