using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core;
using Training.Facade.Common;

namespace Training.Facade
{
    public sealed class UserRoleView : IdentityUser
    {
        public List<string> Roles { get; set; }
    }
}
