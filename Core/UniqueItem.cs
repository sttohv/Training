using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class UniqueItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
