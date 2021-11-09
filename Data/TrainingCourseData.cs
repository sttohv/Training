using System;
using Training.Data.Common;

namespace Training.Data
{
    public sealed class TrainingCourseData: BaseData
    {
        public string Title { get; set; }
        public string AreaId { get; set; }
        public int MaxPeopleInTraining { get; set; }
        public DateTime? CourseTime { get; set; }

    }
}
