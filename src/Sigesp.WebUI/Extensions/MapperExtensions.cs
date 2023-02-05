using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;

namespace Sigesp.WebUI.Extensions
{
    public static class MapperExtensions
    {
        public static ApplicationUserViewModel MapWithChildren<TDestination>(ApplicationUser applicationUser)
        {
            var applicationUserRet = new ApplicationUserViewModel() {
                UserId = applicationUser.Id,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                ApplicationUserRoles = applicationUser.ApplicationUserRoles.Select(x => x.ApplicationRole.NormalizedName).ToList()
            };

            return applicationUserRet;
            
        }
    }
}