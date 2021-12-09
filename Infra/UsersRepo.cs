using System.Linq;
using Training.Data;
using Training.Domain;
using Training.Domain.Repos;
using Training.Infra.Common;

namespace Training.Infra
{
    public sealed class UsersRepo : PagedRepo<User, UserData>, IUsersRepo
    {
        public UsersRepo() : this(null) { }

        public UsersRepo(ApplicationDbContext c) :base(c, c?.Users) { }
        protected internal override User toEntity(UserData d) => new(d);
        protected internal override UserData toData(User e) => e?.Data ?? new UserData();

        protected internal override IQueryable<UserData> applyFilters(IQueryable<UserData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.FirstMidName.Contains(SearchString) ||
                     x.LastName.ToString().Contains(SearchString) ||
                     x.PhoneNumber.ToString().Contains(SearchString) ||
                     x.AreadId.ToString().Contains(SearchString) ||
                     (x.ValidFrom != null && x.ValidFrom.ToString().Contains(SearchString)) ||
                     (x.ValidTo != null && x.ValidFrom.ToString().Contains(SearchString))||
                     x.Email.ToString().Contains(SearchString));
        }

    }
}
