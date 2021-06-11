using System;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantCreationDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? OrderLimitTimeInMinutes { get; set; }
        public bool? IsOpen { get; set; }

        // address
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressExtraInformation { get; set; }
        // !address
    }
}
