using Training.Domain;
using Training.Domain.Repos;
using Training.Facade;
using Training.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Tests.Pages.Common;

namespace Training.Tests.Pages
{
    [TestClass]
    public class TrainingCoursesPageTests : BasePageTests<TrainingCourse, TrainingCourseView>
    {

        private class testTrainingCoursesRepo : TestRepo<TrainingCourse>, ITrainingCoursesRepo { }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new testTrainingCoursesRepo();
            pageModel = new TrainingCoursesPage((ITrainingCoursesRepo)mockRepo);
        }
    }
}
