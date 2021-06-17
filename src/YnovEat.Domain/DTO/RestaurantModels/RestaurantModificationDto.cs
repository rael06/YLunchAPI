using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels;
using YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels;
using YnovEat.Domain.DTO.RestaurantModels.RestaurantCategoryModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantModificationDto
    {
        [Required] public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Base64Image { get; set; }
        public string Base64Logo { get; set; }
        public bool? IsOpen { get; set; }

        // address
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }

        public string AddressExtraInformation { get; set; }
        // !address

        public ICollection<ClosingDateCreationDto> ClosingDates { get; set; }

        public ICollection<DayOpeningTimesCreationDto> WeekOpeningTimes { get; set; }

        public ICollection<RestaurantCategoryCreationDto> Categories { get; set; }

        public Restaurant UpdateRestaurant(Restaurant restaurant,
            ICollection<RestaurantCategory> allRestaurantCategories)
        {
            restaurant.Name = Name ?? restaurant.Name;
            restaurant.PhoneNumber = PhoneNumber ?? restaurant.PhoneNumber;
            restaurant.Email = Email ?? restaurant.Email;
            restaurant.Base64Image = Base64Image ?? restaurant.Base64Image;
            restaurant.Base64Logo = Base64Logo ?? restaurant.Base64Logo;
            restaurant.IsOpen = IsOpen ?? restaurant.IsOpen;
            restaurant.ZipCode = ZipCode ?? restaurant.ZipCode;
            restaurant.Country = Country ?? restaurant.Country;
            restaurant.City = City ?? restaurant.City;
            restaurant.StreetNumber = StreetNumber ?? restaurant.StreetNumber;
            restaurant.StreetName = StreetName ?? restaurant.StreetName;
            restaurant.AddressExtraInformation = AddressExtraInformation ??
                                                 restaurant.AddressExtraInformation;
            restaurant.LastUpdateDateTime = DateTime.Now;
            restaurant.ClosingDates = ClosingDates?
                .Select(x => x.CreateClosingDate(restaurant.Id)).ToList() ?? restaurant.ClosingDates;
            restaurant.WeekOpeningTimes = WeekOpeningTimes?.Select(day =>
                day.CreateDayOpeningTimes(restaurant.Id)
            ).ToList() ?? restaurant.WeekOpeningTimes;
            restaurant.Categories = Categories?
                .Select(x =>
                {
                    var existingCategory = allRestaurantCategories
                        .Where(y => Categories.Any(z => z.Name.Equals(y.Name)))
                        .FirstOrDefault(y => y.Name.Equals(x.Name));
                    return existingCategory ?? x.CreateRestaurantCategory();
                })
                .ToList() ?? restaurant.Categories;

            return restaurant;
        }
    }
}
