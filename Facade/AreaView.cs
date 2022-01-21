using System.ComponentModel.DataAnnotations;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class AreaView:NamedView
    {
        //[Display(Name = "Area Name")] public string Name { get; set; }
        [Display(Name = "Boss")] public string AreaBossId { get; set; }
        [Display(Name = "Boss name")] public string AreaBossName { get; set; }
    }
}