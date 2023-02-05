using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sigesp.Domain.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(bool isMultiTenant)
        {
            IsMultiTenant = isMultiTenant;
        }

        //Construtor vazio para o EF
        public ApplicationUser() { }

        public ContaUsuario ContaUsuario { get; set; }
        public Professor Professor { get; set; }
        public bool IsMultiTenant { get; set; }


        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ServidorEstado ServidorEstado { get; set; }

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual ICollection<ApplicationNotification> ApplicationNotifications { get; set; }
    }
}