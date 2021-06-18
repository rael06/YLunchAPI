using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace YnovEat.Domain.ModelsAggregate.UserAggregate
{
    public class UserWithRoles : User
    {
        public ICollection<IdentityRole> Roles { get; set; }

        public UserWithRoles(User user, IEnumerable<IdentityRole> roles) : base(user)
        {
            Roles = roles.ToList();
        }
    }
}
