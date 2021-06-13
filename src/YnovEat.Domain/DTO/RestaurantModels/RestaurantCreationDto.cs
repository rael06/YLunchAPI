using System;
using System.Collections.Generic;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels;
using YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantCreationDto
    {
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

        public ICollection<DateTime> ClosingDates { get; set; } = new List<DateTime>();

        public ICollection<DayOpeningTimesCreationDto> WeekOpeningTimes { get; set; } =
            new List<DayOpeningTimesCreationDto>();
    }
}
