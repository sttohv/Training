using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class AreaView:NamedView
    {
        [Display(Name = "Boss")] public string AreaBossId { get; set; }
        [Display(Name = "Boss")] public string AreaBossName { get; set; }
    }
}