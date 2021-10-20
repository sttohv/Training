using System.ComponentModel.DataAnnotations;
using Training.Core;

namespace Training.Data.Common
{
    public abstract class BaseData : UniqueItem, IEntityData
    {
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}