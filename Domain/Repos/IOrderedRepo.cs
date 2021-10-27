using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain.Repos
{
    public interface IOrderedRepo
    {
        public string SortOrder { get; set; }

        public string CurrentSort { get; }
    }
}
