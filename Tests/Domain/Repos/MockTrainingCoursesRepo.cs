using Training.Domain;
using Training.Domain.Repos;

namespace Training.Tests.Domain.Repos
{
    public class MockTrainingCoursesRepo : TestRepo<TrainingCourse>, ITrainingCoursesRepo
    {
    }
}
