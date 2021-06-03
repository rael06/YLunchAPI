using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using YnovEatApi.Data.Core;

namespace YnovEatApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        private string _roles;

        public new string Roles
        {
            get => _roles;
            set
            {
                if (value != null && !value.Contains(UserRoles.SuperAdmin))
                    _roles = UserRoles.SuperAdmin + "," + value;
            }
        }

        public AuthorizeAttribute()
        {
        }

        public AuthorizeAttribute(string policy) : base(policy)
        {
        }
    }
}
