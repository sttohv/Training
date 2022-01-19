using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;
using Training.Domain.Repos;
using Training.Facade;
using Training.Infra;
using Training.Pages.Common;

namespace Training.Pages
{
    public class TrainingCoursesPage : ViewPage<TrainingCourse, TrainingCourseView>
    {
        //Ära näpi järgmist rida!
        public override string PageTitle => "TrainingCourses";
        public TrainingCoursesPage(ApplicationDbContext c) : this(new TrainingCoursesRepo(c), c) { }
        protected internal TrainingCoursesPage(ITrainingCoursesRepo r, ApplicationDbContext c = null) : base(r, c) { }
        protected internal override TrainingCourseView toViewModel(TrainingCourse c)
        {
            if (isNull(c)) return null;
            var v = Copy.Members(c.Data, new TrainingCourseView());
            //v.InstructorCourses = new List<CourseAssignmentView>();
            //if (i.CourseAssignments is null) return v;
            //v.InstructorCourses.AddRange(i.CourseAssignments.Select(toCourseAssignmentView).ToList());
            v.AreaName = c.Area?.Name;
            return v;
        }
        protected internal override TrainingCourse toEntity(TrainingCourseView c)
        {
            var d = Copy.Members(c, new TrainingCourseData());
            var obj = new TrainingCourse(d);
            //if (v?.InstructorCourses is null) return obj;
            //foreach (var c in v.InstructorCourses) obj.AddCourse(c?.CourseId);
            return obj;
        }
        public SelectList Areas
        {
            get
            {
                var l = new GetRepo().Instance<IAreasRepo>().Get();
                return new SelectList(l, "Id", "Name", Item?.AreaId);
            }
        }


        protected internal override void doBeforeCreate(InstructorView v, string[] selectedCourses = null)
        {
            if (isNull(v)) return;
            var assignments = new List<CourseAssignmentView>();
            foreach (var course in selectedCourses ?? Array.Empty<string>())
            {
                var courseToAdd = new CourseAssignmentView
                {
                    CourseId = course
                };
                assignments.Add(courseToAdd);
            }

            v.InstructorCourses = assignments;
        }
        protected internal override void doBeforeEdit(InstructorView v, string[] selectedCourses = null)
            => doBeforeCreate(v, selectedCourses);
        internal static CourseAssignmentView toCourseAssignmentView(CourseAssignment c)
            => new() { CourseId = c.Course.Id, Number = c.Course.Number, Name = c.Course.Name };
        public bool IsAssigned(SelectListItem item)
            => Item?.InstructorCourses? //facade list nimi
                .FirstOrDefault(x =>
                    x.CourseId == item.Value) is not null;
        public SelectList Courses =>
            new(context.Users.OrderBy(x => x.FirstMidName).AsNoTracking(),
                "Id", "FirstMidName");
    }
}
