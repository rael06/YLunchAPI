using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using YnovEat.Domain.DTO.RestaurantModels.ClosingDatesModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.DTO.RestaurantModels
{
    public class RestaurantReadDto : IDtoConverter<Restaurant>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? EmailConfirmationDateTime { get; set; }
        public bool IsOpen { get; set; }
        public bool IsCurrentlyOpenToOrder { get; set; }
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
        public ICollection<ClosingDateReadDto> ClosingDatesReadDtoCollection { get; set; }

        public RestaurantReadDto(Restaurant restaurant)
        {
            FromEntity(restaurant);
        }

        public void FromEntity(Restaurant entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            PhoneNumber = entity.PhoneNumber;
            Email = entity.Email;
            IsEmailConfirmed = entity.IsEmailConfirmed;
            EmailConfirmationDateTime = entity.EmailConfirmationDateTime;
            IsOpen = entity.IsOpen;
            IsPublished = entity.IsPublished;
            CreationDateTime = entity.CreationDateTime;
            LastUpdateDateTime = entity.LastUpdateDateTime;
            ZipCode = entity.ZipCode;
            Country = entity.Country;
            City = entity.City;
            StreetNumber = entity.StreetNumber;
            StreetName = entity.StreetName;
            AddressExtraInformation = entity.AddressExtraInformation;
            OwnerId = entity.OwnerId;
            ClosingDatesReadDtoCollection = entity.ClosingDates.Select(x => new ClosingDateReadDto(x)).ToList();
        }
    }
}
