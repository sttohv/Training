using Training.Data.Common;

namespace Training.Data
{
    public sealed class InstructorAssignementData :BaseData
    {
        public string TrainingCourseId { get; set; }
        public string UserId { get; set; } //peab checkima kas person.type == instructor
        public string Location { get; set; } //kas on vaja? nice to have
    }
}
