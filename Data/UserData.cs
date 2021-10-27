using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Training.Data.Common
{
    public sealed class UserData : BaseData  //kus ma referencen Identyt, Enne oli :IdentityUser
    {
        [StringLength(50)] public string LastName { get; set; }
        [StringLength(50)] public string FirstMidName { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string ContactInfoId { get; set; }  //on seda vaja siia?
        public string AreadId { get; set; } //mis ma teen kui seda on vaja ainult töötajal
    }
}
