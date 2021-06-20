using System;
using System.Collections.Generic;
using System.Linq;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels;
using YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels;
using YnovEat.Domain.DTO.RestaurantModels.RestaurantCategoryModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantCreationDto
    {
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

        public ICollection<ClosingDateCreationDto> ClosingDates { get; set; } =
            new List<ClosingDateCreationDto>();

        public ICollection<DayOpeningTimesCreationDto> WeekOpeningTimes { get; set; } =
            new List<DayOpeningTimesCreationDto>();

        public ICollection<RestaurantCategoryCreationDto> Categories { get; set; } =
            new List<RestaurantCategoryCreationDto>();
    }
}
