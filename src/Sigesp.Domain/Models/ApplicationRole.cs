using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sigesp.Domain.Models
{
    public class ApplicationRole : IdentityRole
    {        
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}