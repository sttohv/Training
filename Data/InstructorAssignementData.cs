namespace Data
{
    public sealed class InstructorAssignementData :BaseData
    {
        public string TrainingCourseId { get; set; }
        public string PersonId { get; set; } //peab checkima kas person.type == instructor
        public string Location { get; set; } //kas on vaja?
    }
}
