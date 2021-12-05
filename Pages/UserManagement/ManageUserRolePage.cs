using Microsoft.AspNetCore.Identity;
using System;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Common;
using Training.Domain.Repos;
using Training.Facade;
using Training.Infra;
using Training.Pages.Common;

namespace Training.Pages.UserManagement
{
    public class ManageUserRolePage:ViewPage<User,UserView>
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public override string PageTitle => "Role manager";
        public ManageUserRolePage(ApplicationDbContext c) :this(new UsersRepo(c), c) { }
        protected internal ManageUserRolePage(IUsersRepo r, ApplicationDbContext c = null): base(r, c) { }

        protected internal override UserView toViewModel(User e)
        {
            throw new NotImplementedException();
        }

        protected internal override User toEntity(UserView e)
        {
            throw new NotImplementedException();
        }
    }
}
