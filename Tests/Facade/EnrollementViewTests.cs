using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Facade;
using Training.Facade.Common;

namespace Training.Tests.Facade
{
   
    [TestClass]
    public class EnrollementViewTests : SealedClassTests<EnrollementView, BaseView>
    {
         [TestMethod] public void TrainingCourseIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void UserIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void TrainingCourseTitleTest() => IsReadWriteProperty<string>();
    }
    
}
