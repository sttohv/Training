using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Data;
using Training.Domain;
using Training.Infra.Common;

namespace Training.Tests.Infra.Common
{
    [TestClass]
    public class FilteredRepoTests : AbstractClassTests<FilteredRepo<TrainingCourse, TrainingCourseData>
        , CrudRepo<TrainingCourse, TrainingCourseData>>
    {
    }
}
