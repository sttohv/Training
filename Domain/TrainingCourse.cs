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
            instructorAssignement = getLazy<InstructorAssignement, IInstructorAssignementsRepo>(x => x?.Get(Id));
        }

        public string Title => Data?.Title ?? "Unspecified";
        public string AreaId => Data?.AreaId ?? "Unspecified";
        public int MaxPeopleInTraining => Data?.MaxPeopleInTraining ?? 0;
        public DateTime? CourseTime => Data?.CourseTime; //kas siin peab olema max value v min value - pole vahet, seda ei pea isegi olema

        public Area Area => area.Value;

        //testid ei tööta, kui see internal on :)))))))
        internal Lazy<Area> area { get; }

        public ICollection<User> Users => Enrollments?.Select(x => x.User).ToList();
        public ICollection<Enrollement> Enrollments => enrollements.Value;
        
        //oli enne internal
        internal Lazy<ICollection<Enrollement>> enrollements { get; }


        public InstructorAssignement InstructorAssignement => instructorAssignement.Value;
        //oli enne internal
        internal Lazy<InstructorAssignement> instructorAssignement { get; }
    }
}
