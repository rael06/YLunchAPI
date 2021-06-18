using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.ModelsAggregate.UserAggregate
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ConfirmationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public DateTime? PhoneNumberConfirmationDateTime { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        public bool IsAccountConfirmed => ConfirmationDateTime != null;
        public bool IsAccountActivated { get; set; }
        public virtual RestaurantUser RestaurantUser { get; set; }
        public virtual Customer Customer { get; set; }

        public User()
        {
        }

        public User(User user)
        {
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            CreationDateTime = user.CreationDateTime;
            ConfirmationDateTime = user.ConfirmationDateTime;
            LastUpdateDateTime = user.LastUpdateDateTime;
            PhoneNumberConfirmationDateTime = user.PhoneNumberConfirmationDateTime;
            EmailConfirmationDateTime = user.EmailConfirmationDateTime;
            IsAccountActivated = user.IsAccountActivated;
            RestaurantUser = user.RestaurantUser;
            Customer = user.Customer;
        }
    }
}
