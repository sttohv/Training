using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain.Common;
using Training.Domain.Repos;

namespace Training.Domain
{
    public sealed class TrainingCourse: BaseEntity<TrainingCourseData>
    {
        public TrainingCourse() : this(null) { }
        public TrainingCourse(TrainingCourseData d) : base(d)
        {
            area = getLazy<Area, IAreasRepo>(x => x?.Get(AreaId));
            enrollements = getLazy<Enrollement, IEnrollementsRepo>(x => x?.GetByTrainingCourseId(Id));
            instructorAssignement = getLazy<InstructorAssignement, IInstructorAssignmentsRepo>(x => x?.Get(Id));
        }

        public string AreaId => Data?.AreaId ?? "Unspecified";
        public Area Area => area.Value;
        internal Lazy<Area> area { get; }

        public ICollection<Enrollement> Enrollments => enrollements.Value;

        internal Lazy<ICollection<Enrollement>> enrollements { get; }


        public InstructorAssignement InstructorAssignement => instructorAssignement.Value;
        internal Lazy<InstructorAssignement> instructorAssignement { get; }
    }
}
