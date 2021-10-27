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
            user = getLazy<User, IUsersRepo>(x => x?.Get(Id));
            trainingCourse = getLazy<TrainingCourse, ITrainingCoursesRepo>(x => x?.Get(TrainingCourseId));
        }
        public User User => user.Value;
        internal Lazy<User> user { get; }
        public string BooksId => Data?.UserId ?? "Unspecified";

        public TrainingCourse TrainingCourse => trainingCourse.Value;
        internal Lazy<TrainingCourse> trainingCourse { get; }
        public string TrainingCourseId => Data?.TrainingCourseId ?? "Unspecified";
    }
}
