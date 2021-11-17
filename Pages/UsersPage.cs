using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Aids;
using Training.Data.Common;
using Training.Domain;
using Training.Domain.Common;
using Training.Domain.Repos;
using Training.Facade;
using Training.Infra;
using Training.Pages.Common;

namespace Training.Pages
{
    public class UsersPage:ViewPage<User, UserView>
    {
        public override string PageTitle => "Users";

        public UsersPage(ApplicationDbContext c) : this(new UsersRepo(c), c) { }

        protected internal UsersPage(IUsersRepo r, ApplicationDbContext c = null) : base(r, c) { }

        protected internal override UserView toViewModel(User e)
        {
            if (isNull(e)) return null;
            var v = Copy.Members(e.Data, new UserView());
            return v;
        }
        protected internal override User toEntity(UserView e)
        {
            var d = Copy.Members(e, new UserData());
            return new User(d);
        }
        public SelectList Users
        {
            get
            {
                var l = new GetRepo().Instance<IUsersRepo>().Get();
                return new SelectList(l, "Id", "Name", Item?.Id);
            }
        }
    }
}
