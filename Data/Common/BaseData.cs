using Core;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class BaseData : UniqueItem, IEntityData
    {
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}