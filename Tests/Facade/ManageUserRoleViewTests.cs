using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Facade;
using Training.Facade.Common;

namespace Training.Tests.Facade
{
    [TestClass]
    public class ManageUserRoleViewTests: SealedClassTests<ManageUserRoleView, BaseView>
    {
        [TestMethod] public void RoleIdTest() => IsReadWriteProperty<string>();
        [TestMethod] public void RoleNameTest() => IsReadWriteProperty<string>();
        [TestMethod] public void SelectedTest() => IsReadWriteProperty<bool>();

    }
}
