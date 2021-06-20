using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.ModelsAggregate.RestaurantAggregate
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Base64Image { get; set; }
        public string Base64Logo { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        public bool IsOpen { get; set; }
        public bool IsCurrentlyOpenToOrder =>
            IsOpen &&
            // Todo set also based on order limit time
            !ClosingDates.Any(x => x.ClosingDateTime.Date.Equals(DateTime.Now.Date));

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

        public string OwnerId { get; set; }
        public virtual RestaurantOwner Owner { get; set; }
        public virtual ICollection<ClosingDate> ClosingDates { get; set; } = new List<ClosingDate>();
        public virtual ICollection<DayOpeningTimes> WeekOpeningTimes { get; set; } = new List<DayOpeningTimes>();
        public virtual ICollection<RestaurantUser> RestaurantUsers { get; set; } = new List<RestaurantUser>();

        public virtual ICollection<RestaurantCategory> Categories { get; set; } =
            new List<RestaurantCategory>();

        public virtual ICollection<RestaurantProduct> RestaurantProducts { get; set; } = new List<RestaurantProduct>();

        public static Restaurant Create(RestaurantCreationDto restaurantCreationDto, CurrentUser user, IEnumerable<RestaurantCategory> allRestaurantCategories)
        {
            var restaurantId = Guid.NewGuid().ToString();
            return new Restaurant
            {
                Id = restaurantId,
                Name = restaurantCreationDto.Name,
                PhoneNumber = restaurantCreationDto.PhoneNumber,
                Email = restaurantCreationDto.Email,
                Base64Image = restaurantCreationDto.Base64Image,
                Base64Logo = restaurantCreationDto.Base64Logo,
                IsEmailConfirmed = false,
                EmailConfirmationDateTime = null,
                IsOpen = restaurantCreationDto.IsOpen ?? false,
                CreationDateTime = DateTime.Now,
                ZipCode = restaurantCreationDto.ZipCode,
                Country = restaurantCreationDto.Country,
                City = restaurantCreationDto.City,
                StreetNumber = restaurantCreationDto.StreetNumber,
                StreetName = restaurantCreationDto.StreetName,
                AddressExtraInformation = restaurantCreationDto.AddressExtraInformation,
                OwnerId = user.Id,
                Owner = user.RestaurantUser as RestaurantOwner,

                ClosingDates = restaurantCreationDto.ClosingDates.Select(x => ClosingDate.Create(x, restaurantId)).ToList(),

                WeekOpeningTimes = restaurantCreationDto.WeekOpeningTimes.Select(x =>
                    DayOpeningTimes.Create(x, restaurantId)
                ).ToList(),

                Categories = restaurantCreationDto.Categories
                    .Select(x =>
                    {
                        var existingCategory = allRestaurantCategories.FirstOrDefault(y => y.Name.Equals(x.Name));
                        return existingCategory ?? RestaurantCategory.Create(x);
                    })
                    .ToList()
            };
        }

        public void Update(RestaurantModificationDto restaurantModificationDto, ICollection<RestaurantCategory> allRestaurantCategories)
        {
            Name = restaurantModificationDto.Name ?? Name;
            PhoneNumber = restaurantModificationDto.PhoneNumber ?? PhoneNumber;
            Email = restaurantModificationDto.Email ?? Email;
            Base64Image = restaurantModificationDto.Base64Image ?? Base64Image;
            Base64Logo = restaurantModificationDto.Base64Logo ?? Base64Logo;
            IsOpen = restaurantModificationDto.IsOpen ?? IsOpen;
            ZipCode = restaurantModificationDto.ZipCode ?? ZipCode;
            Country = restaurantModificationDto.Country ?? Country;
            City = restaurantModificationDto.City ?? City;
            StreetNumber = restaurantModificationDto.StreetNumber ?? StreetNumber;
            StreetName = restaurantModificationDto.StreetName ?? StreetName;
            AddressExtraInformation = restaurantModificationDto.AddressExtraInformation ??
                                                 AddressExtraInformation;
            LastUpdateDateTime = DateTime.Now;
            ClosingDates = restaurantModificationDto.ClosingDates?
                .Select(x => ClosingDate.Create(x, Id)).ToList() ?? ClosingDates;
            WeekOpeningTimes = restaurantModificationDto.WeekOpeningTimes?.Select(x =>
                DayOpeningTimes.Create(x, Id)
            ).ToList() ?? WeekOpeningTimes;
            Categories = restaurantModificationDto.Categories?
                .Select(x =>
                {
                    var existingCategory = allRestaurantCategories
                        .Where(y => Categories.Any(z => z.Name.Equals(y.Name)))
                        .FirstOrDefault(y => y.Name.Equals(x.Name));
                    return existingCategory ?? RestaurantCategory.Create(x);
                })
                .ToList() ?? Categories;
        }
    }
}
