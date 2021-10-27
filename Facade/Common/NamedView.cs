using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Training.Facade.Common
{
    public abstract class NamedView: BaseView
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z -']*$")]
        [DisplayName("Name")]
        public string Name { get; set; }

    }
}
