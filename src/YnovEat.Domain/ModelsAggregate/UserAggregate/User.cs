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
        [Required] public string Firstname { get; set; }
        [Required] public string Lastname { get; set; }
        [Required] public DateTime CreationDateTime { get; set; }
        public DateTime? ConfirmationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public DateTime? PhoneNumberConfirmationDateTime { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        [NotMapped] public bool IsAccountConfirmed => ConfirmationDateTime != null;
        public bool IsAccountActivated { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
