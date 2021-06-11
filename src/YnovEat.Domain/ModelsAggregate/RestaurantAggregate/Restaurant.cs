using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        public int? OrderLimitTimeInMinutes { get; set; }
        public bool IsOpen { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        // address
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressExtraInformation { get; set; }
        // !address

        public string RestaurantOwnerId { get; set; }
        public virtual RestaurantOwner Owner { get; set; }
        public virtual ICollection<ClosingDate> ClosingDates { get; set; } = new List<ClosingDate>();
        public virtual ICollection<DayOpeningHours> DaysOpeningHours { get; set; } = new List<DayOpeningHours>();
        public virtual ICollection<RestaurantUser> RestaurantUsers { get; set; } = new List<RestaurantUser>();

        public virtual ICollection<RestaurantCategory> Categories { get; set; } =
            new List<RestaurantCategory>();

        public virtual ICollection<RestaurantProduct> Products { get; set; } = new List<RestaurantProduct>();
    }
}
