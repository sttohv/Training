using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Core;
using Training.Domain.Repos;

namespace Training.Tests
{
    public abstract class TestRepo<TClass> : IRepo<TClass> where TClass : IBaseEntity
    {
        public string ErrorMessage { get; set; }
        public TClass EntityInDb { get; set; }
        public object Result { get; set; } = null;
        public List<string> Actions { get; } = new();
        public async Task<bool> AddAsync(TClass obj) => await complete($"AddAsync {obj?.Id}");
        public async Task<bool> DeleteAsync(TClass obj) => await complete($"Delete {obj?.Id}");
        public async Task<bool> UpdateAsync(TClass obj) => await complete($"UpdateAsync {obj?.Id}");
        public async Task<List<TClass>> GetAsync() => await list("List");
        public List<TClass> Get() { throw new System.NotImplementedException(); }
        public async Task<TClass> GetAsync(string id) => await item($"Get {id}");
        public TClass Get(string id) => get($"Get {id}");
        private async Task<TClass> item(string v) => await complete(v, (TClass)Result);
        private async Task<List<TClass>> list(string v) => await complete(v, (List<TClass>)Result);
        private async Task<TResult> complete<TResult>(string s, TResult r)
        {
            await complete(s);
            return r;
        }
        private async Task<bool> complete(string s)
        {
            await Task.CompletedTask;
            Actions.Add(s);
            return Result is not null;
        }
        protected TClass get(string s)
        {
            Actions.Add(s);
            return (TClass)Result;
        }
        protected List<TClass> getList(string s)
        {
            Actions.Add(s);
            return (List<TClass>)Result;
        }


        public int? PageIndex { get; set; }
        public int TotalPages { get; } = 0;
        public bool HasNextPage { get; } = false;
        public bool HasPreviousPage { get; } = false;
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public string CurrentSort { get; set; }
    }
}
