using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public abstract class PersonData :BaseData
    {
        [StringLength(50)] public string LastName { get; set; }
        [StringLength(50)] public string FirstMidName { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
