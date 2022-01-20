using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;
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
        public override async Task<bool> DeleteAsync(TrainingCourse e)
        {
            await removeAssignments(e);
            var isOk = await base.DeleteAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> AddAsync(TrainingCourse e)
        {
            await updateAssignments(e);
            var isOk = await base.AddAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        public override async Task<bool> UpdateAsync(TrainingCourse e)
        {
            await updateAssignments(e);
            var isOk = await base.UpdateAsync(e);
            await db.SaveChangesAsync();
            return isOk;
        }
        internal static async Task removeAssignments(TrainingCourse e)
        {
            await removeCourseAssignments(e?.Enrollments);
        }
        internal static async Task updateAssignments(TrainingCourse i)
        {
            await updateCourseAssignments(i);
        }
        internal static async Task updateCourseAssignments(TrainingCourse i)
        {
            await removeCourseAssignments(i?.Enrollments, i?.NewlyAssignedParticipants);
            await addCourseAssignments(i);
        }

        internal static async Task addCourseAssignments(TrainingCourse i)
        {
            if (i is null) return;
            var r = new GetRepo().Instance<IEnrollementsRepo>();
            foreach (var id in i.NewlyAssignedParticipants)
            {
                if (i.Enrollments?
                    .FirstOrDefault(x => x.UserId == id) is not null) continue;
                var d = new EnrollementData { UserId = id, TrainingCourseId = i.Id };
                await r.AddAsync(new Enrollement(d));
            }
        }

        private static async Task removeCourseAssignments(
            IEnumerable<Enrollement> l, ICollection<string> doNotRemove = null)
        {
            if (l is null) return;
            var r = new GetRepo().Instance<IEnrollementsRepo>();
            foreach (var e in l)
            {
                if (doNotRemove?.Contains(e.UserId) ?? false) continue;
                await r.DeleteAsync(e);
            }
        }

    }
}

