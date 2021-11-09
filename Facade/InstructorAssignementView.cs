using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class InstructorAssignementView:BaseView
    {
        [Display(Name = "Training course")] public string TrainingCourseId { get; set; }

        [Display(Name = "User")] public string UserId { get; set; } 

        public string Location { get; set; }
    }
}
