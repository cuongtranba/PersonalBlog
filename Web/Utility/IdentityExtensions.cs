using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Models;
using Web.Models.Entity;
using Web.Models.Model;

namespace Web.Utility
{
    public static class IdentityExtensions
    {
        private static UserManager<ApplicationUser> UserManager => new ApplicationUserManager(new UserStore<ApplicationUser>());

        public static string GetId(this IIdentity identity)
        {
            return identity.GetUserId();
        }
    }
}