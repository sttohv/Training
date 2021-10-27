using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Repos
{
    public interface IPagedRepo
    {
        public int? PageIndex { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; }
    }
}
