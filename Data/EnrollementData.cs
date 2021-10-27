using Training.Data.Common;

namespace Training.Data
{
    public sealed class EnrollementData: BaseData
    {
        public string TrainingCourseId { get; set; }
        public string UserId { get; set; } 
        //Kuna on ainult personid, siis peab kontrollima, et see oleks trainee
    }
}
