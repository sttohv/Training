using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Training.Core;
using Training.Domain.Repos;
using Training.Infra;

namespace Training.Pages.Common
{
    public abstract class ViewPage<TEntity, TView> : PagedPage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected ViewPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }
        public async virtual Task<IActionResult> OnGetIndexAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            PageIndex = pageIndex;
            SearchString = searchString;
            CurrentFilter = currentFilter;
            SortOrder = sortOrder;
            Items = (await repo.GetAsync()).Select(toViewModel).ToList();
            return Page();
        }
    }
}
