using System;
using Microsoft.AspNetCore.Identity;

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
    }
}
