using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Training.Core;

namespace Training.Data.Common
{
    public sealed class UserData : IdentityUser, IEntityData  //kus ma referencen Identyt, Enne oli :IdentityUser
    {
        [StringLength(50)] public string LastName { get; set; }
        [StringLength(50)] public string FirstMidName { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
       // public string ContactInfoId { get; set; }  //
        public string AreadId { get; set; } //mis ma teen kui seda on vaja ainult töötajal  default null ja kui töötaja, siis tal võimalik see lisada  
        public byte[] RowVersion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        byte[] IBaseEntity.RowVersion => throw new NotImplementedException();
        // ja kui tal mitu trenni nkn, siis oleks list
    }
}
