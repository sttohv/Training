using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Training.Facade
{
    public sealed class UserRoleView : IdentityUser
    {
        public List<string> Roles { get; set; }
    }
}
