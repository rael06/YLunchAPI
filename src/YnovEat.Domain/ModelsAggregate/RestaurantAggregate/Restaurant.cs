using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime EmailConfirmationDateTime { get; set; }
        public int OrderLimitTimeInMinutes { get; set; }
        public bool IsOpen { get; set; }
        public bool IsPublished { get; set; }
        [Required] public DateTime CreationDateTime { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        // address
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }

        public string ExtraInformation { get; set; }

        // !address
        public string MainAdminId { get; set; }
        public virtual User MainAdmin { get; set; }
        public virtual ICollection<ClosingDate> ClosingDates { get; set; } = new List<ClosingDate>();
        public virtual ICollection<DayOpeningHours> DaysOpeningHours { get; set; } = new List<DayOpeningHours>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<Restaurant_RestaurantCategory> Restaurant_RestaurantCategory_Links { get; set; } =
            new List<Restaurant_RestaurantCategory>();

        [NotMapped]
        public ICollection<RestaurantCategory> RestaurantCategories =>
            Restaurant_RestaurantCategory_Links
                .Where(rc => rc.RestaurantId == Id)
                .Select(rc => rc.RestaurantCategory)
                .ToList();

        public virtual ICollection<RestaurantProduct> Products { get; set; } = new List<RestaurantProduct>();

        public virtual ICollection<RestaurantProductCategory> ProductCategories { get; set; } =
            new List<RestaurantProductCategory>();
    }
}
