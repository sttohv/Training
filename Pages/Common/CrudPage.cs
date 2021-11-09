using System.Collections.Generic;
using Training.Core;
using Training.Domain.Repos;
using Training.Infra;

namespace Training.Pages.Common
{
    public abstract class CrudPage<TEntity, TView> : BasePage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected CrudPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }

        public IList<TView> Items { get; set; }
    }
}
