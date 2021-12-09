using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class EnrollementView:BaseView
    {
        [Display(Name = "Training course")] public string TrainingCourseId { get; set; }
        [Display(Name = "User")] public string UserId { get; set; }
        [Display(Name = "Course Title")]public string TrainingCourseTitle { get; set; }
    }
}
