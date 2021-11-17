using System;
using Training.Data;
using Training.Domain.Common;
using Training.Domain.Repos;

namespace Training.Domain
{
    public sealed class Enrollement : BaseEntity<EnrollementData>
    {
        public Enrollement() : this(null) { }
        public Enrollement(EnrollementData d) : base(d)
        {
           // user = getLazy<User, IUsersRepo>(x => x?.Get(UserId));
            trainingCourse = getLazy<TrainingCourse, ITrainingCoursesRepo>(x => x?.Get(TrainingCourseId));
        }
         public string UserId => Data?.UserId ?? "Unspecified";
        public string TrainingCourseId => Data?.TrainingCourseId ?? "Unspecified";

        public User User => user.Value;
        internal Lazy<User> user { get; }

        public TrainingCourse TrainingCourse => trainingCourse.Value;
        internal Lazy<TrainingCourse> trainingCourse { get; }
         }
}
