using System;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime EmailConfirmationDateTime { get; set; }
        public int OrderLimitTimeInMinutes { get; set; }
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
        public string ExtraInformation { get; set; }
        // !address

        public string RestaurantOwnerId { get; set; }
    }
}
