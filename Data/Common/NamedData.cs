using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core;

namespace Training.Data.Common
{
    public abstract class NamedData : BaseData, INamedEntityData
    {
        [StringLength(50)] public string Name { get; set; }

    }
}
