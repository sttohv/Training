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
using System;
using System.Collections.Generic;

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
            v.TrainingUsers = new List<EnrollementView>();
            if (v.TrainingUsers is null) return v;
            v.TrainingUsers.AddRange(v.TrainingUsers.Select(toCourseAssignmentView).ToList());
            v.AreaName = c.Area?.Name;
            return v;
        }
        protected internal override TrainingCourse toEntity(TrainingCourseView c)
        {
            var d = Copy.Members(c, new TrainingCourseData());
            var obj = new TrainingCourse(d);
            if (d?.InstructorCourses is null) return obj;
            foreach (var c in d.InstructorCourses) obj.AddCourse(c?.CourseId);
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


        protected internal override void doBeforeCreate(TrainingCourseView v, string[] selectedCourses = null)
        {
            if (isNull(v)) return;
            var assignments = new List<EnrollementView>();
            foreach (var course in selectedCourses ?? Array.Empty<string>())
            {
                var courseToAdd = new EnrollementView
                {
                    TrainingCourseId = course
                };
                assignments.Add(courseToAdd);
            }

            v.TrainingUsers = assignments;
        }
        protected internal override void doBeforeEdit(TrainingCourseView v, string[] selectedCourses = null)
            => doBeforeCreate(v, selectedCourses);

        internal static EnrollementView toCourseAssignmentView(Enrollement c)
            => new() { TrainingCourseId = c.TrainingCourse.Id, UserId = c.User.Id, TrainingCourseTitle = c.TrainingCourse.Title };
        public bool IsAssigned(SelectListItem item)
            => Item?.TrainingUsers? 
                .FirstOrDefault(x =>
                    x.Id == item.Value) is not null;
        public SelectList Courses =>
            new(context.Users.OrderBy(x => x.FirstMidName).AsNoTracking(),
                "Id", "FirstMidName");
    }
}
