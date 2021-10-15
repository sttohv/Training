using Core;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class BaseData : UniqueItem, IEntityData
    {
       // public int Id { get; set; } //seda pole ju vist siia vaja
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}