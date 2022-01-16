using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Domain;
using Training.Infra.Common;

namespace Training.Tests.Infra.Common
{
    [TestClass]
    public class OrderedRepoTests : AbstractClassTests<OrderedRepo<TrainingCourse, TrainingCourseData>
         , FilteredRepo<TrainingCourse, TrainingCourseData>>
    {
    }
}
