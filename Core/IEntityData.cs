using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IEntityData : IBaseEntity
    {
        public new string Id { get; set; }
        public new byte[] RowVersion { get; set; }
    }
}
