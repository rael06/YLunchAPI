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
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? IsOpen { get; set; }

        // address
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressExtraInformation { get; set; }
        // !address

        public ICollection<ClosingDateCreationDto> ClosingDates { get; set; } = new List<ClosingDateCreationDto>();

        public ICollection<DayOpeningTimesCreationDto> WeekOpeningTimes { get; set; } =
            new List<DayOpeningTimesCreationDto>();

        public ICollection<RestaurantCategoryCreationDto> Categories { get; set; } =
            new List<RestaurantCategoryCreationDto>();

        public Restaurant UpdateRestaurant(Restaurant restaurant,
            ICollection<RestaurantCategory> allRestaurantCategories)
        {
            restaurant.Name = Name ?? restaurant.Name;
            restaurant.PhoneNumber = PhoneNumber ?? restaurant.PhoneNumber;
            restaurant.Email = Email ?? restaurant.Email;
            restaurant.IsOpen = IsOpen ?? restaurant.IsOpen;
            restaurant.ZipCode = ZipCode ?? restaurant.ZipCode;
            restaurant.Country = Country ?? restaurant.Country;
            restaurant.City = City ?? restaurant.City;
            restaurant.StreetNumber = StreetNumber ?? restaurant.StreetNumber;
            restaurant.StreetName = StreetName ?? restaurant.StreetName;
            restaurant.AddressExtraInformation = AddressExtraInformation ??
                                                 restaurant.AddressExtraInformation;
            restaurant.LastUpdateDateTime = DateTime.Now;
            restaurant.ClosingDates = ClosingDates.Select(x => x.CreateClosingDate(restaurant.Id)).ToList();
            restaurant.WeekOpeningTimes = WeekOpeningTimes.Select(day =>
                day.CreateDayOpeningTimes(restaurant.Id)
            ).ToList();
            restaurant.Categories = Categories
                .Select(x =>
                {
                    var existingCategory = allRestaurantCategories.FirstOrDefault(y => y.Name.Equals(x.Name));
                    return existingCategory ?? x.CreateRestaurantCategory();
                })
                .ToList();

            return restaurant;
        }
    }
}
