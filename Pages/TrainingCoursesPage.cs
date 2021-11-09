using Microsoft.AspNetCore.Mvc.Rendering;
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
        public override string PageTitle => "Training Courses";
        public TrainingCoursesPage(ApplicationDbContext c) : this(new TrainingCoursesRepo(c), c) { }
        protected internal TrainingCoursesPage(ITrainingCoursesRepo r, ApplicationDbContext c = null) : base(r, c) { }
        protected internal override TrainingCourseView toViewModel(TrainingCourse c)
        {
            if (isNull(c)) return null;
            var v = Copy.Members(c.Data, new TrainingCourseView());
            v.AreaName = c.Area?.Name;
            return v;
        }
        protected internal override TrainingCourse toEntity(TrainingCourseView c)
        {
            var d = Copy.Members(c, new TrainingCourseData());
            return new TrainingCourse(d);
        }
        public SelectList Areas
        {
            get
            {
                var l = new GetRepo().Instance<IAreasRepo>().Get();
                return new SelectList(l, "Id", "Name", Item?.AreaId);
            }
        }
    }
}
