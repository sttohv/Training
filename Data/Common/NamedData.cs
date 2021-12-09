using System.ComponentModel.DataAnnotations;
using Training.Core;

namespace Training.Data.Common
{
    public abstract class NamedData : BaseData, INamedEntityData
    {
        [StringLength(50)] public string Name { get; set; }

    }
}
