using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using System.Linq;
using Training.Aids;
using Training.Data;
using Training.Domain;
using Training.Domain.Repos;
using Training.Facade;
using Training.Infra;
using Training.Pages.Common;

namespace Training.Pages
{
    public class AreasPage : ViewPage<Area, AreaView>
    {
        public override string PageTitle => "Departments";
        public AreasPage(ApplicationDbContext c) : this(new AreasRepo(c), c) { }
        protected internal AreasPage(IAreasRepo r, ApplicationDbContext c = null) : base(r, c) { }
        protected internal override AreaView toViewModel(Area d)
        {
            if (isNull(d)) return null;
            var v = Copy.Members(d.Data, new AreaView());
            v.AreaBossName = d.AreaBoss?.FullName;
            return v;
        }
        protected internal override Area toEntity(AreaView v)
        {
            var d = Copy.Members(v, new AreaData());
            return new Area(d);
        }
        public SelectList Instructors =>
            new(context.Users.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.AreaBossId);
    }
}
