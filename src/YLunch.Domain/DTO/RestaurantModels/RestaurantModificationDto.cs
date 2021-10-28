using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YLunch.Domain.DTO.RestaurantModels.ClosingDateModels;
using YLunch.Domain.DTO.RestaurantModels.OpeningTimeModels;
using YLunch.Domain.DTO.RestaurantModels.RestaurantCategoryModels;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.DTO.RestaurantModels
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
        public bool? IsPublic { get; set; }

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
    }
}
