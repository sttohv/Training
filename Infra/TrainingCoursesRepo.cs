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

        //instrucor on trainingCourse
        //courseass on enrollement
        public override async Task<bool> DeleteAsync(Instructor e)
        {
            await removeAssignments(e);
            var isOk = await base.DeleteAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> AddAsync(Instructor e)
        {
            await updateAssignments(e);
            var isOk = await base.AddAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> UpdateAsync(Instructor e)
        {
            await updateAssignments(e);
            var isOk = await base.UpdateAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        internal static async Task removeAssignments(Instructor e)
        {
            await removeCourseAssignments(e?.CourseAssignments);
        }
        internal static async Task updateAssignments(Instructor i)
        {
            await updateCourseAssignments(i);
        }
        internal static async Task updateCourseAssignments(Instructor i)
        {
            await removeCourseAssignments(i?.CourseAssignments, i?.NewlyAssignedCourses);
            await addCourseAssignments(i);
        }

        internal static async Task addCourseAssignments(Instructor i)
        {
            if (i is null) return;
            var r = new GetRepo().Instance<ICourseAssignmentsRepo>();
            foreach (var id in i.NewlyAssignedCourses)
            {
                if (i.CourseAssignments?
                    .FirstOrDefault(x => x.CourseId == id) is not null) continue;
                var d = new CourseAssignmentData { CourseId = id, InstructorId = i.Id };
                await r.AddAsync(new CourseAssignment(d));
            }
        }

        private static async Task removeCourseAssignments(
            IEnumerable<CourseAssignment> l, ICollection<string> doNotRemove = null)
        {
            if (l is null) return;
            var r = new GetRepo().Instance<ICourseAssignmentsRepo>();
            foreach (var e in l)
            {
                if (doNotRemove?.Contains(e.CourseId) ?? false) continue;
                await r.DeleteAsync(e);
            }
        }

    }
}

