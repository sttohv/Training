using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Training.Facade
{
    //TODO: something
    public abstract class UserView : IdentityUser, IBaseEntityView
    {

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z '-]*$")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")] public string FullName { get; set; }

        [Display(Name = "New Photo")] public IFormFile Photo { get; set; }

        [Display(Name = "Current Photo")] public string PhotoAsString { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Contract Starting Date")]
        public DateTime ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Contact Ending Date")]
        public DateTime ValidTo { get; set; }
       
        //public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        //string IBaseEntity.Id => throw new NotImplementedException();

        //byte[] IBaseEntity.RowVersion => throw new NotImplementedException();


        //kuidas siia lisan, kes 
    }
}
