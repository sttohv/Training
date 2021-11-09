using System.Linq;
using Training.Data;
using Training.Domain;
using Training.Domain.Repos;
using Training.Infra.Common;

namespace Training.Infra
{
    public sealed class TrainingCoursesRepo : PagedRepo<TrainingCourse, TrainingCourseData>, ITrainingCoursesRepo
    {
        public TrainingCoursesRepo() : this(null) { }
        public TrainingCoursesRepo(ApplicationDbContext c) : base(c, c?.TrainingCourses) { }
        protected internal override TrainingCourse toEntity(TrainingCourseData d) => new(d);
        protected internal override TrainingCourseData toData(TrainingCourse e) => e?.Data ?? new TrainingCourseData();
        protected internal override IQueryable<TrainingCourseData> applyFilters(IQueryable<TrainingCourseData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.Title.Contains(SearchString) ||
                     x.MaxPeopleInTraining.ToString().Contains(SearchString) ||
                     x.CourseTime.ToString().Contains(SearchString));
        }
    }
}

