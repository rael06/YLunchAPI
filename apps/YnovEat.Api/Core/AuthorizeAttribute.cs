using System;
using System.Reflection;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;

namespace YnovEat.Api.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeAttribute(string roles)
        {
            if (!roles.Contains(UserRoles.SuperAdmin))
                Roles = UserRoles.SuperAdmin + "," + roles;
        }

        public AuthorizeAttribute()
        {
            Roles = string.Join(",", UserRoles.List);
        }
    }
}
