using System;
using Training.Data;
using Training.Domain.Common;
using Training.Domain.Repos;

namespace Training.Domain
{
    public sealed class InstructorAssignement: BaseEntity<InstructorAssignementData>
    {
        public InstructorAssignement() : this(null) { }
        public InstructorAssignement(InstructorAssignementData d) : base(d)
        {
            user = getLazy<User, IUsersRepo>(x => x?.Get(Id));
            trainingCourse = getLazy<TrainingCourse, ITrainingCoursesRepo>(x => x?.Get(TrainingCourseId));
        }
        public string TrainingCourseId => Data?.TrainingCourseId ?? "Unspecified";
        public string UserId => Data?.UserId ?? "Unspecified";
        
        public string Location => Data?.Location ?? "Unspecified";

        public User User => user.Value;
        internal Lazy<User> user { get; }

        public TrainingCourse TrainingCourse => trainingCourse.Value;
        internal Lazy<TrainingCourse> trainingCourse { get; }

    }
}
