using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.UserAggregate
{
    public class User  : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public DateTime PhoneNumberConfirmationDateTime { get; set; }
        public DateTime EmailConfirmationDateTime { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
