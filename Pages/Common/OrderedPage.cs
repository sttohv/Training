using Training.Core;
using Training.Domain.Repos;
using Training.Infra;

namespace Training.Pages.Common
{
    public abstract class OrderedPage<TEntity, TView> : FilteredPage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected OrderedPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }

        public override string SortOrder
        {
            get => repo.SortOrder;
            set => repo.SortOrder = value;
        }
        public override string CurrentSort => repo.CurrentSort;
    }
}
