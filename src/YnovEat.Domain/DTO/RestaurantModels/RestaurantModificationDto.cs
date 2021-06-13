using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDateModels;
using YnovEat.Domain.DTO.RestaurantModels.OpeningTimeModels;
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

        public ICollection<DateTime> ClosingDates { get; set; } = new List<DateTime>();

        public ICollection<DayOpeningTimesCreationDto> WeekOpeningTimes { get; set; } =
            new List<DayOpeningTimesCreationDto>();
    }
}
