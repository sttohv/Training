using System.Collections.Generic;
using Training.Data;
using Training.Domain;
using Training.Domain.Repos;
using Training.Infra.Common;

namespace Training.Infra
{
    public sealed class AreasRepo:PagedRepo<Area, AreaData>, IAreasRepo
    {
        public AreasRepo() : this(null) { }
        public AreasRepo(ApplicationDbContext c) : base(c, c?.Areas) { }

        protected internal override Area toEntity(AreaData d) => new(d);

        protected internal override AreaData toData(Area e) => e?.Data ?? new AreaData();

        public List<Area> GetByAdministratorId(string id)
            => getRelated(x => x.AreaBossId == id);

        //protected internal override IQueryable<AreaData> applyFilters(IQueryable<AreaData> query)
        //{
        //    if (SearchString is null) return query;
        //    return query.Where(
        //        x => x.Name.Contains(SearchString) ||
        //             (x.StartDate != null && x.StartDate.ToString().Contains(SearchString)) ||
        //             (x.Budget != null && x.Budget.ToString().Contains(SearchString))
        //    );
        //}
    }
}
